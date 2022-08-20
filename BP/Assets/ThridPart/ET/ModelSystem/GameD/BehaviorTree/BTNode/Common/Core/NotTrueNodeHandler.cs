using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [BehaviorTree]
    public class NotTrueNodeHandler : ANodeHandler<NotTrueNode>
    {
        public override async ETTask<bool> Run(NotTrueNode node, BTEnv env)
        {
            await ETTask.CompletedTask;
            return false;
        }
    }
}
