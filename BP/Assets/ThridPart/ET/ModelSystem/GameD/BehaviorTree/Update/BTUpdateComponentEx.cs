using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [ObjectSystem]
    public class BTUpdateComponentAwakeSystem : AwakeSystem<BTUpdateComponent,int>
    {
        public override void Awake(BTUpdateComponent self,int interval)
        {
            self.interval = interval;
            self.timer = TimerComponent.Instance.NewRepeatedTimer(interval, () => Update(self));
        }



        void Update(BTUpdateComponent self)
        {
            long instanceId = self.InstanceId;
            self.Domain.GetComponent<UpdateActionMgrComponent>().Add(() => AddToAIMgr(self, instanceId));
        }

        void AddToAIMgr(BTUpdateComponent self, long instanceId)
        {
            if (self.IsDisposed || self.InstanceId != instanceId) return;
            BTHelper.Execute(BTSwitch.BTUpdate,self.Parent);
        }
    }
}
