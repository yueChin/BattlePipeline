using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class SpellComponent : Entity
    {
        [BsonIgnore]
        public Dictionary<int, SpellCoolDownTimer> CoolDownTimers = new Dictionary<int, SpellCoolDownTimer>();

        // 一般不是玩家用的,队友或者怪物才会用到这个
        public HashSet<int> CanUse = new HashSet<int>();

        [BsonIgnore]
        public Dictionary<int, Spell> CurrUsing = new Dictionary<int, Spell>();

        public int SpellState; // >0表示使用技能的硬直状态

    }
}
