using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [BehaviorTree]
    public class SelectorNodeHandler : ANodeHandler<SelectorNode>
    {
        public override async ETTask<bool> Run(SelectorNode node, BTEnv env)
        {

            foreach (var v in node.Children)
            {
                if (await BTHelper.RunNode(v, env))
                {
                    return true;
                }
            }
            return false;

        }
    }
}
