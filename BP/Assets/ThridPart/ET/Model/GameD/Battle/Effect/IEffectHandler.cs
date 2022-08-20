using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public interface IEffectHandler
    {
        void Handle(EffectTriggerType effectTriggerType, Effect effect);
    }
}
