using System.Collections.Generic;

namespace ET
{
    [Node(NodeClassifyType.Action)]
    public class SpellCastEffect2TargetsNode : Node
    {
        [NodeInput(typeof(Spell))]
        public string Spell;

        [NodeInput(typeof (List<long>))]
        public string Targets;

        [NodeField]
        public int EffectId;
    }
}