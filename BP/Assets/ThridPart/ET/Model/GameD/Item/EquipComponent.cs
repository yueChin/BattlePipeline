using System.Collections.Generic;

namespace ET
{
    public class EquipComponent : Entity
    {
        // 装备点对应装备
        public Dictionary<int, Item> AllEquips = new Dictionary<int, Item>();
    }
}