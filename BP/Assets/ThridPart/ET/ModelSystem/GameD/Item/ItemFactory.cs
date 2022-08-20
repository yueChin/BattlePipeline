using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public static class ItemFactory
    {
        // 活动,副本等奖励需要直接先生成的情况,生成的结果会放到传入的items中
        public static void Create(Scene domain, int configId, int num, List<Item> items)
        {
            if (items == null)
            {
                return;
            }
            var config = ItemConfigCategory.Instance.Get(configId);
            if (num <= config.MaxAddNum)
            {
                var item = Create(domain, configId, num);
                items.Add(item);
                return;
            }
            else
            {

                int splitCount = num / config.MaxAddNum;
                int lastNum = num % config.MaxAddNum;
                if (lastNum != 0) splitCount++;
                else lastNum = config.MaxAddNum;
                Item item = null;
                for (int i = 0; i < splitCount - 1; i++)
                {
                    item = Create(domain,configId, config.MaxAddNum);
                    items.Add(item);
                }
                item = Create(domain, configId, lastNum);
                items.Add(item);
            }
        }

        // 简单创建,适用于明确知道创建出来的道具数量不会超过设定最大值的
        public static Item Create(Entity parent, int configId, int num)
        {
            var config = ItemConfigCategory.Instance.Get(configId);
            if (num > config.MaxAddNum) return null;
            var item = EntityFactory.CreateWithParent<Item>(parent);
            item.ItemConfigId = configId;
            item.Num = num;
            return item;
        }

        public static Item CreateFromProto(InventoryComponent com, ItemProto proto)
        {
            var item = EntityFactory.CreateWithParentAndId<Item>(com,proto.ItemId);
            item.ItemConfigId = proto.ConfigId;
            item.Num = proto.Num;
            item.Pos = proto.Pos;
            return item;
        }
        
        public static Item CreateFromProto(EquipComponent com, ItemProto proto)
        {
            var item = EntityFactory.CreateWithParentAndId<Item>(com,proto.ItemId);
            item.ItemConfigId = proto.ConfigId;
            item.Num = proto.Num;
            item.Pos = proto.Pos;
            return item;
        }
        


    }
}
