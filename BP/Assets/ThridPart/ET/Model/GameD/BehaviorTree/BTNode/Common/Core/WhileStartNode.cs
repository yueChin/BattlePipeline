using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [Node(NodeClassifyType.Composite)]
    [Serializable]
    public class WhileStartNode : Node
    {
        [NodeField]
        public int RepeatCount = 1;      
    }
}
