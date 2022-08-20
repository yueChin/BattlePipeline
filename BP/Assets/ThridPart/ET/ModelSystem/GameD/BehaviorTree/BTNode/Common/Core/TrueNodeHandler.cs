using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [BehaviorTree]
    public class TrueNodeHandler : ANodeHandler<TrueNode>
    {
        public override async ETTask<bool> Run(TrueNode node, BTEnv env)
        {

            foreach (var v in node.Children)
            {
                await BTHelper.RunNode(v, env);
            }
            return true;

        }
    }
}
