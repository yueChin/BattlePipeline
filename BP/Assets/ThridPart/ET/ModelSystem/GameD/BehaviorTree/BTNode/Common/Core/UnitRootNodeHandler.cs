using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [BehaviorTree]
    public class UnitRootNodeHandler : ANodeHandler<UnitRootNode>
    {
        public override async ETTask<bool> Run(UnitRootNode node, BTEnv env)
        {

            var _s = env.Get<Entity>(BTEnvKey.Entity) as Unit;
            if (_s == null)
            {
                Log.Error("Root´íÎó,ÎÞ·¨×ª»»");
                return false;
            }
            env.Add<Unit>(node.Unit, _s);
            foreach (var v in node.Children)
            {
                await BTHelper.RunNode(v, env);
            }
            return true;

        }
    }
}
