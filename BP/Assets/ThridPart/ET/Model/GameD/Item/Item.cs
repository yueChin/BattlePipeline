using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class Item : Entity
    {
        public int ItemConfigId;
        public ItemConfig ItemConfig => ItemConfigCategory.Instance.Get(ItemConfigId);
        
        public int Num;

        public int Pos; // 哪个格子
    }
}
