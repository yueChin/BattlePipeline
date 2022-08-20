using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public static class EffectFactory
    {
        public static Effect Create(Buff buff, int configId)
        {
            var owner = buff.GetOwner();
            var effect = EntityFactory.CreateWithParent<Effect>(owner);
            effect.EffectConfigId = configId;
            effect.Buff = buff;
            return effect;
        }

        public static Effect Create(Spell spell, int configId)
        {
            var caster = spell.Caster;
            var effect = EntityFactory.CreateWithParent<Effect>(caster);
            effect.EffectConfigId = configId;
            effect.Spell = spell;
            return effect;
        }
    }
}
