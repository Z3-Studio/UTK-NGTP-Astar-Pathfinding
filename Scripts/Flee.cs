using Pathfinding;
using Z3.NodeGraph.Core;
using Z3.NodeGraph.Tasks;
using UnityEngine;

namespace Z3.NodeGraph.TaskPack.AstarPathfinding
{
    [NodeCategory(Categories.AstarPathfinding)]
    [NodeDescription("TODO")]
    public class Flee : ActionTask
    {
        [ParameterDefinition(AutoBindType.SelfBind)]
        public Parameter<AIPath> agent;
        public Parameter<Vector3> target;
        public Parameter<float> escapeDistance;

        private AIPath Agent => agent.Value;

        protected override void StartAction()
        {
            Agent.canMove = true;
            Agent.canSearch = true; 
        }

        protected override void UpdateAction()
        {
            Vector3 oppositeDirection = (Agent.transform.position - target.Value).normalized * escapeDistance.Value;
            Agent.destination = Agent.transform.position + oppositeDirection;

            if (Vector3.Distance(Agent.transform.position, target.Value) >= escapeDistance.Value)
            {
                EndAction();
            }
        }

        protected override void StopAction()
        {
            Agent.canMove = false;
            Agent.canSearch = false;
        }
    }
}