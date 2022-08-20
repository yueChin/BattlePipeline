using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class BuffEventMgrComponent : Entity
    {
        public static BuffEventMgrComponent Instance;
        public Dictionary<int, IBuffAddHandler> AddEventHandlers = new Dictionary<int, IBuffAddHandler>();
        public Dictionary<int, IBuffUpdateHandler> UpdateEventHandlers = new Dictionary<int, IBuffUpdateHandler>();
        public Dictionary<int, IBuffRemoveHandler> RemoveEventHandlers = new Dictionary<int, IBuffRemoveHandler>();
        public Dictionary<int, IBuffTickHandler> TickEventHandlers = new Dictionary<int, IBuffTickHandler>();
    }
}
