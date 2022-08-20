using System.Collections.Generic;

namespace ET
{
    [Node(NodeClassifyType.Action)]
    public class SpellCastChildNode : Node
    {
        [NodeInput(typeof(Spell))]
        public string Spell;

        [NodeField]
        public int FlagBuffId;
        [NodeField]
        public List<int> SpellConfigIds = new List<int>();
    }
}