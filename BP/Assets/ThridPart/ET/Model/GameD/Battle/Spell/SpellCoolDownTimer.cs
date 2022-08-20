using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class SpellCoolDownTimer : Entity
    {
        public long coolDownTimer;

        public long startTime;
        public long endTime;

        public override void Dispose()
        {
            if (IsDisposed) return;
            base.Dispose();
            TimerComponent.Instance.Remove(coolDownTimer);
        }
    }
}
