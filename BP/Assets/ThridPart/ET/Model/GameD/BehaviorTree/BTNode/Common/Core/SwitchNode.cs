using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [Node(NodeClassifyType.Composite)]
    [Serializable]
    public class SwitchNode : Node
    {
        [NodeField]
        public BTSwitch switchType;
    }
}
