using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [Node(NodeClassifyType.Root)]
    [Serializable]
    public class UnitRootNode : Node
    {
        [GUI_ReadOnly]
        [NodeOutput(typeof(Unit))]
        public string Unit = BTEnvKey.Unit;
    }
}
