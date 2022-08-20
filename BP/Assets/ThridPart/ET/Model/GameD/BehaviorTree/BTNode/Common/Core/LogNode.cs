using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [Node(NodeClassifyType.Action)]
    public class LogNode : Node
    {
        [NodeField]
        public string Info;
    }
}
