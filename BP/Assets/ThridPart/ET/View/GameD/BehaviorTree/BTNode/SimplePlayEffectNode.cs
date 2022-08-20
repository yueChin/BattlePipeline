using UnityEngine;

namespace ET
{
    [Node(NodeClassifyType.Action)]
    public class SimplePlayEffectNode : Node
    {
        [NodeField]
        public string ResName;

        [NodeField]
        public Vector3 Offset;

        [NodeField]
        public Vector3 Dir;
        [NodeInput(typeof(Unit))]
        public string Origin;
    }
}