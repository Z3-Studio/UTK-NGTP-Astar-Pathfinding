using Pathfinding;
using Z3.NodeGraph.Core;
using Z3.NodeGraph.Tasks;
using UnityEngine;

namespace Z3.NodeGraph.TaskPack.AstarPathfinding
{
    [System.Serializable]
    public class AIPathParameters
    {
        public float maxSpeed = 10f;
        public float rotationSpeed = 360f;
        public float slowdownDistance = 3f;
        [Min(0.4f)]
        public float endReachedDistance = 2f;
    }

    [NgName("Set AstarAI Parameters")]
    [NodeCategory(Categories.AstarPathfinding)]
    [NodeDescription("Set the parameters defined in IAstarAI")]
    public class SetAstarAIParameters : ActionTask
    {
        [ParameterDefinition(AutoBindType.SelfBind)]
        public Parameter<AIPath> aiPath;
        public Parameter<AIPathParameters> aiPathParameters;

        public override string Info => $"AstarAI Parameters = {aiPathParameters}";

        protected override void StartAction()
        {
            AIPath component = aiPath.Value;
            AIPathParameters parameters = aiPathParameters.Value;

            component.maxSpeed = parameters.maxSpeed;
            component.rotationSpeed = parameters.rotationSpeed;
            component.slowdownDistance = parameters.slowdownDistance;
            component.endReachedDistance = parameters.endReachedDistance;

            EndAction();
        }
    }
}