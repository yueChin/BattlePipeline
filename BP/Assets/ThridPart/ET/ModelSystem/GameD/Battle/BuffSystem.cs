using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public static class BuffSystem
    {
        public static Unit GetOwner(this Buff buff)
        {
            return buff.GetParent<BuffComponent>().GetParent<Unit>();
        }

        public static Unit GetCaster(this Buff buff)
        {
            return buff.DomainScene().GetComponent<UnitComponent>().Get(buff.casterId);
        }

        public static void Add(this Buff self,int layer = 1)
        {
            self.createTime = TimeHelper.ServerNow();
            self.stack = layer;
            Log.Debug($"Buff添加 {self.BuffConfigId}  {self.stack}  {layer}");
            if (self.stack > self.BuffConfig.MaxStack)
                self.stack = self.BuffConfig.MaxStack;

            if (self.BuffConfig.TickSpan > 0)
            {
                self.buffTickTimer = TimerComponent.Instance.NewRepeatedTimer(self.BuffConfig.TickSpan, self.Tick);
            }
            if (self.BuffConfig.Duration > 0)
            {
                self.expireTime = self.createTime + self.BuffConfig.Duration;
                self.expireTimer = TimerComponent.Instance.NewOnceTimer(self.expireTime,()=> self.GetParent<BuffComponent>().TimeOut(self.Id));
            }

            BuffEventMgrComponent.Instance.PublishAddEvent(self);
            self.ExecuteEffect( EffectTriggerType.BuffAdd);
        }

        static HashSet<int> GetEffect(this BuffConfig config, EffectTriggerType triggerType)
        {
            return BuffConfigCategory.Instance.GetByTriggerType(config.Id, triggerType);
        }

        public static void Tick(this Buff self)
        {
            if (self.BuffConfig.TickSpan <=0)
            {
                return;
            }
            self.ExecuteEffect( EffectTriggerType.BuffTick);
        }

        public static void SetExpireTime(this Buff self, long expireTime)
        {
            TimerComponent.Instance.Remove(self.expireTimer);
            self.expireTimer = 0;
            self.expireTime = expireTime;
            if (self.expireTime > 0)
            {
                self.expireTimer = TimerComponent.Instance.NewOnceTimer(expireTime, () => self.GetParent<BuffComponent>().TimeOut(self.Id));
            }
            BuffEventMgrComponent.Instance.PublishUpdateEvent(self);
        }

        public static void Remove(this Buff self)
        {
            BuffEventMgrComponent.Instance.PublishRemoveEvent(self);
            self.ExecuteEffect( EffectTriggerType.BuffRemove);
            
        }

        public static void TimeOut(this Buff self)
        {
            BuffEventMgrComponent.Instance.PublishRemoveEvent(self);
            self.ExecuteEffect( EffectTriggerType.BuffTimeOut);

        }

        public static void UpdateStack(this Buff buff, int change)
        {
            if (change == 0) return;
            buff.stack += change;
            if (buff.stack > buff.BuffConfig.MaxStack)
                buff.stack = buff.BuffConfig.MaxStack;
            BuffEventMgrComponent.Instance.PublishUpdateEvent(buff);
        }

        public static void SetStack(this Buff buff, int stack)
        {
            if (stack <= 1 || stack>buff.BuffConfig.MaxStack)
            {
                Log.Error("设置了超过范围的层数");
                return;
            }
            buff.stack = stack;
        }

        public static void UpdateTickSpan(this Buff buff, int tickSpan)
        {
            buff.buffTickSpan = tickSpan;
            TimerComponent.Instance.Remove(ref buff.buffTickTimer);
            buff.buffTickTimer = TimerComponent.Instance.NewRepeatedTimer(buff.buffTickSpan, buff.Tick);
        }

        public static void ExecuteEffect(this Buff buff, EffectTriggerType trigger)
        {
            var effects = buff.BuffConfig.GetEffect(trigger);
            if (effects != null)
            {
                foreach (var v in effects)
                {
                    using (var effect =EffectFactory.Create(buff,v))
                    {
                        EffectEventMgrComponent.Instance.Handle(trigger, effect);
                    }   
                }
            }
        }

    }
}
