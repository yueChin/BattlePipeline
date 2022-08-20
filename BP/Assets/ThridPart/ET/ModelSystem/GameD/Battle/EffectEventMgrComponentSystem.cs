using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [ObjectSystem]
    public class EffectComponentAwakeSystem : AwakeSystem<EffectEventMgrComponent>
    {
        public override void Awake(EffectEventMgrComponent self)
        {
            EffectEventMgrComponent.Instance = self;
            self.Load();
        }
    }

    [ObjectSystem]
    public class EffectComponentLoadSystem : LoadSystem<EffectEventMgrComponent>
    {
        public override void Load(EffectEventMgrComponent self)
        {
            self.Load();
        }
    }

    [ObjectSystem]
    public class EffectComponentDestorySystem : DestroySystem<EffectEventMgrComponent>
    {
        public override void Destroy(EffectEventMgrComponent self)
        {
            self.AllHandlers.Clear();
            EffectEventMgrComponent.Instance = null;
        }
    }

    public static class EffectEventMgrComponentEx
    {
        public static void Load(this EffectEventMgrComponent self)
        {
            self.AllHandlers.Clear();
            foreach (var v in Game.EventSystem.GetTypes(typeof(EffectAttribute)))
            {
                var attr = v.GetCustomAttributes(typeof(EffectAttribute), false)[0] as EffectAttribute;
                self.AllHandlers.Add((int)attr.effectType, Activator.CreateInstance(v) as IEffectHandler);
            }
        }

        public static void Handle(this EffectEventMgrComponent self, EffectTriggerType effectTriggerType, Effect effect)
        {
            self.AllHandlers[effect.EffectConfig.EffectType].Handle(effectTriggerType, effect);
        }
    }
}
