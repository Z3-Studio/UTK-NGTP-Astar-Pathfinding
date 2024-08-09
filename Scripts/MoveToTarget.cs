using Pathfinding;
using Z3.NodeGraph.Core;
using Z3.NodeGraph.Tasks;
using UnityEngine;

namespace Z3.NodeGraph.TaskPack.AstarPathfinding
{
    [NodeCategory(Categories.AstarPathfinding)]
    [NodeDescription("TODO")]
    public class MoveToTarget : ActionTask
    {
        [ParameterDefinition(AutoBindType.SelfBind)]
        [SerializeField] private Parameter<AIPath> aiPath;
        [SerializeField] private Parameter<Vector3> target;

        public override string Info => $"Move To {target}";

        private AIPath Agent => aiPath.Value;

        protected override void StartAction()
        {
            Agent.canMove = true;
            Agent.canSearch = true;
        }

        protected override void UpdateAction()
        {
            Agent.destination = target.Value;

            if (Agent.reachedDestination)
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