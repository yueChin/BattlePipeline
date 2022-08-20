namespace ET
{
    [Node(NodeClassifyType.Action)]
    public class SpellFinishNode : Node
    {
        [NodeInput(typeof(Spell))]
        public string Spell;
    }
}