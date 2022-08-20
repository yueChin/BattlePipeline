using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [ObjectSystem]
    public class BuffEventMgrComponentAwakeSystem : AwakeSystem<BuffEventMgrComponent>
    {
        public override void Awake(BuffEventMgrComponent self)
        {

            BuffEventMgrComponent.Instance = self;
            self.Load();
        }
    }

    [ObjectSystem]
    public class BuffEventMgrComponentLoadSystem : LoadSystem<BuffEventMgrComponent>
    {
        public override void Load(BuffEventMgrComponent self)
        {
            self.Load();
        }
    }

    [ObjectSystem]
    public class BuffEventMgrComponentDestorySystem : DestroySystem<BuffEventMgrComponent>
    {
        public override void Destroy(BuffEventMgrComponent self)
        {
            self.AddEventHandlers.Clear();
            self.RemoveEventHandlers.Clear();
            self.UpdateEventHandlers.Clear();
            self.TickEventHandlers.Clear();
            BuffEventMgrComponent.Instance = null;
        }
    }

    public static class BuffEventMgrComponentEx
    {
        public static void Load(this BuffEventMgrComponent self)
        {
            self.AddEventHandlers.Clear();
            self.RemoveEventHandlers.Clear();
            self.UpdateEventHandlers.Clear();
            self.TickEventHandlers.Clear();
            foreach (var v in Game.EventSystem.GetTypes(typeof(BuffAttribute)))
            {
                var attr = v.GetCustomAttributes(typeof(BuffAttribute), false)[0] as BuffAttribute;
                var obj = Activator.CreateInstance(v);
                if (obj is IBuffAddHandler)
                {
                    self.AddEventHandlers[(int)attr.buffType] = obj as IBuffAddHandler;
                }
                if (obj is IBuffRemoveHandler)
                {
                    self.RemoveEventHandlers[(int)attr.buffType] = obj as IBuffRemoveHandler;
                }
                if (obj is IBuffUpdateHandler)
                {
                    self.UpdateEventHandlers[(int)attr.buffType] = obj as IBuffUpdateHandler;
                }
                if (obj is IBuffTickHandler)
                {
                    self.TickEventHandlers[(int)attr.buffType] = obj as IBuffTickHandler;
                }
            }
        }

        public static void PublishAddEvent(this BuffEventMgrComponent self,Buff buff)
        {
            if (!self.AddEventHandlers.TryGetValue(buff.BuffConfigId, out var handler)) return;
            handler.Add(buff);
        }

        public static void PublishUpdateEvent(this BuffEventMgrComponent self, Buff buff)
        {
            if (!self.UpdateEventHandlers.TryGetValue(buff.BuffConfigId, out var handler)) return;
            handler.Update(buff);
        }

        public static void PublishRemoveEvent(this BuffEventMgrComponent self, Buff buff)
        {
            if (!self.RemoveEventHandlers.TryGetValue(buff.BuffConfigId, out var handler)) return;
            handler.Remove(buff);
        }
    }
}
