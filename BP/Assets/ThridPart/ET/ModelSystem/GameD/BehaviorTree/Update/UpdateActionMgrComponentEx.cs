using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [ObjectSystem]
    public class UpdateActionMgrComponentAwakeSystem : AwakeSystem<UpdateActionMgrComponent>
    {
        public override void Awake(UpdateActionMgrComponent self)
        {
        }
    }

    [ObjectSystem]
    public class UpdateActionMgrComponentUpdateSystem : UpdateSystem<UpdateActionMgrComponent>
    {
        public override void Update(UpdateActionMgrComponent self)
        {
            if (self.UpdateQueue.Count == 0) return;
            for (int i = 0; i < UpdateActionMgrComponent.ExecutePerFrame; i++)
            {
                self.UpdateQueue.Dequeue().Invoke();
                if (self.UpdateQueue.Count == 0) return;
            }
        }
    }

    public static class UpdateActionMgrComponentEx
    {
        public static void Add(this UpdateActionMgrComponent self, Action action)
        {
            self.UpdateQueue.Enqueue(action);
        }
    }
}
