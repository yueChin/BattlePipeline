using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [Node(NodeClassifyType.Root)]
    [Serializable]
    public class SpellRootNode : Node
    {
        [GUI_ReadOnly]
        [NodeOutput(typeof(Spell))]
        public string Spell = BTEnvKey.Spell;

        [GUI_ReadOnly]
        [NodeOutput(typeof(Unit))]
        public string SpellCaster = BTEnvKey.SpellCaster;

        [GUI_ReadOnly]
        [NodeOutput(typeof(Unit))]
        public string SpellAttacker = BTEnvKey.SpellAttacker;
    }
}
