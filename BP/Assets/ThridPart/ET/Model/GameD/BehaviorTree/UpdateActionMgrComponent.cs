using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    // 场景中的行为树Update管理器
    public class UpdateActionMgrComponent : Entity
    {
        public const int ExecutePerFrame = 30; // 每帧执行多少个

        public Queue<Action> UpdateQueue = new Queue<Action>();
    }
}
