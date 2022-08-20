using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [BehaviorTree]
    public class PlotRootNodeHandler : ANodeHandler<PlotRootNode>
    {
        public override async ETTask<bool> Run(PlotRootNode node, BTEnv env)
        {
            await ETTask.CompletedTask;
            return true;
        }
    }
}
