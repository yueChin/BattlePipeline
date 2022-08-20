using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace ET
{
    // 仅仅战斗中用,而且战斗场景的切换也没必要序列化/反序列化
    public class BuffComponent : Entity
    {
        public Dictionary<long, Buff> Id2Buffs = new Dictionary<long, Buff>();
        public Dictionary<int, HashSet<Buff>> ConfigId2Buffs = new Dictionary<int, HashSet<Buff>>();
        public Dictionary<int, HashSet<Buff>> Type2Buffs = new Dictionary<int, HashSet<Buff>>();

        public Dictionary<int, HashSet<Buff>> RemoveCond2Buffs = new Dictionary<int, HashSet<Buff>>();
    }
}
