using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    // 全局的管理Effect的组件
    public class EffectEventMgrComponent : Entity
    {
        public static EffectEventMgrComponent Instance;
        public Dictionary<int, IEffectHandler> AllHandlers = new Dictionary<int, IEffectHandler>();
    }
}
