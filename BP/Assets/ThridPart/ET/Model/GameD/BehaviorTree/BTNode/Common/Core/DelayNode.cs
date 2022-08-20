using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [Node(NodeClassifyType.Composite)]
    [Serializable]
    public class DelayNode : Node
    {
        [NodeField]
        public bool DelayByInput;
        [GUI_EnableIf("DelayByInput",false)]
        [NodeField]
        public long delayTime;
        [NodeInput(typeof(Entity))]
        public string Entity;
        [NodeInput(typeof(int))]
        public string delayInputTime;
    }
}
