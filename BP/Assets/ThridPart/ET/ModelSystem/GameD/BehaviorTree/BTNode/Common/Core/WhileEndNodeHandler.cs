using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [BehaviorTree]
    public class WhileEndNodeHandler : ANodeHandler<WhileEndNode>
    {
        public override async ETTask<bool> Run(WhileEndNode node, BTEnv env)
        {

            var stack = env.Get<Stack<(WhileStartNode, int)>>(BTEnvKey.While);
            if (stack == null || stack.Count == 0)
            {
                Log.Error("√ª”–’“µΩWhileStartNode");
                return false;
            }

            var _p = stack.Pop();
            if (_p.Item2 < _p.Item1.RepeatCount)
            {
                stack.Push(_p);
                await BTHelper.RunNode(_p.Item1, env);
            }
            foreach (var v in node.Children)
            {
                await BTHelper.RunNode(v, env);
            }
            return true;

        }
    }
}
