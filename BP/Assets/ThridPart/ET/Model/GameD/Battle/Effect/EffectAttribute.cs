using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class EffectAttribute : BaseAttribute
    {
        public EffectType effectType;
        public EffectAttribute(EffectType effectType)
        {
            this.effectType = effectType;
        }
    }
}
