using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class BTUpdateComponent :Entity
    {
        public long timer;
        public int interval;

        public override void Dispose()
        {
            if (IsDisposed) return;
            base.Dispose();
            TimerComponent.Instance.Remove(ref this.timer);
        }
    }
}
