using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [BehaviorTree]
    public class LogNodeHandler : ANodeHandler<LogNode>
    {
        public override async ETTask<bool> Run(LogNode node, BTEnv env)
        {
            Log.Debug(node.Info);
            await ETTask.CompletedTask;
            return true;
        }
    }
}
