namespace ET
{
    [Node(NodeClassifyType.Action)]
    public class SimplePlayAnimNode : Node
    {
        [NodeField]
        public string AnimName;

        [NodeInput(typeof(Unit))]
        public string Unit;
    }
}