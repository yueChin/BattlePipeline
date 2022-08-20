using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class UnitCollideTargetComponent : Entity
    {
        public HashSet<long> CollideTargets = new HashSet<long>();

        public HashSet<long> Handling = new HashSet<long>();

        public long CurrHandle;
    }
}
