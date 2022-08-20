using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [BehaviorTree]
    public class WhileStartNodeHandler : ANodeHandler<WhileStartNode>
    {
        public override async ETTask<bool> Run(WhileStartNode node, BTEnv env)
        {
            var stack = env.Get<Stack<(WhileStartNode, int)>>(BTEnvKey.While);
            if (stack == null)
            {
                stack = new Stack<(WhileStartNode, int)>();
                env.Add(BTEnvKey.While, stack);
            }
            if (stack.Count == 0)
            {
                stack.Push((node, 1));
            }
            else
            {
                var _p = stack.Peek();
                if (_p.Item1 != node)
                {
                    stack.Push((node, 1));
                }
                else
                {
                    // ֵ����
                    _p = stack.Pop();
                    _p.Item2++;
                    stack.Push(_p);
                }
            }
            foreach (var v in node.Children)
            {
                await BTHelper.RunNode(v, env);
            }
            return true;

        }
    }
}
