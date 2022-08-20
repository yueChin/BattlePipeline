using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [BehaviorTree]
    public class TestDialogNodeHandler : ANodeHandler<TestDialogNode>
    {
        public override async ETTask<bool> Run(TestDialogNode node, BTEnv env)
        {
            await ETTask.CompletedTask;
            return true;
        }
    }
}
