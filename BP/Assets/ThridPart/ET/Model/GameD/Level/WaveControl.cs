using System.Collections.Generic;

namespace ET
{
    public class WaveControl : Entity
    {
        public int ConfigId { get; set; }

        public HashSet<long> Timers = new HashSet<long>();
    }
}