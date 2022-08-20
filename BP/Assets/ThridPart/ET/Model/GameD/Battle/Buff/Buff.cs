using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class Buff : Entity
    {
        public int BuffConfigId;
        public BuffConfig BuffConfig
        {
            get
            {
                var config = BuffConfigCategory.Instance.Get(BuffConfigId);
                return config;
            }
        }
        public long casterId;
        public long ownerId;
        public long buffTickTimer; // Tick计时器
        public long buffTickSpan;
        public long expireTime; // 过期时间
        public long expireTimer;//过期计时器
        public int stack; // 层数
        public long createTime;

        public override void Dispose()
        {
            if (IsDisposed) return;
            base.Dispose();
            TimerComponent.Instance.Remove(ref this.expireTimer);
            TimerComponent.Instance.Remove(ref this.buffTickTimer);
        }
    }
}
