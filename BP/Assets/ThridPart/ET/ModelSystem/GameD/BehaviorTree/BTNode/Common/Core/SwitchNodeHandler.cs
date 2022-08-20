using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [BehaviorTree]
    public class SwitchNodeHandler : ANodeHandler<SwitchNode>
    {
        public override async ETTask<bool> Run(SwitchNode node, BTEnv env)
        {

            var envSwitchType = env.Get<BTSwitch>(BTEnvKey.Switch);
            if (node.switchType != envSwitchType)
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
