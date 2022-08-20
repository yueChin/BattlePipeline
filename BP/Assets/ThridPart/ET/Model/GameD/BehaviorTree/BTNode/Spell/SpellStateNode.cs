namespace ET
{
    [Node(NodeClassifyType.Action)]
    public class SpellStateNode : Node
    {
        [NodeInput(typeof(Spell))]
        public string Spell;
    }
}