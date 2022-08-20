using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [BehaviorTree]
    public class SequenceNodeHandler : ANodeHandler<SequenceNode>
    {
        public override async ETTask<bool> Run(SequenceNode node, BTEnv env)
        {
            foreach (var v in node.Children)
            {
                if (!await BTHelper.RunNode(v,env))
                {
                    return false;
                }
            }
            return true;

        }
    }
}
