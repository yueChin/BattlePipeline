using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [BehaviorTree]
    public class DelayNodeHandler : ANodeHandler<DelayNode>
    {
        public override async ETTask<bool> Run(DelayNode node, BTEnv env)
        {

            var entity = env.Get<Entity>(node.Entity);
            long instanceId = entity.InstanceId;
            long time = node.delayTime;
            if (node.DelayByInput)
                time = env.Get<int>(node.delayInputTime);

            await TimerComponent.Instance.InternalWaitAsync(time,null);
            if (entity.IsDisposed || entity.InstanceId != instanceId)
            {
                return false;
            }
            foreach (var v in node.Children)
            {
                await BTHelper.RunNode(v, env);
            }
            return true;

        }
    }
}
