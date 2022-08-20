using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class Effect : Entity
    {
        public int EffectConfigId;
        public EffectConfig EffectConfig
        {
            get => EffectConfigCategory.Instance.Get(EffectConfigId);
        }

        public Buff EffectBuff
        {
            get => Buff;
        }

        public Spell EffectSpell
        {
            get => Spell;
        }

        public Unit Target;

        public Buff Buff;
        public Spell Spell;
    }
}
