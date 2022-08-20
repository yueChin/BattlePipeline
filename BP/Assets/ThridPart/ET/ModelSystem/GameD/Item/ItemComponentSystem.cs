using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [ObjectSystem]
    public class ItemComponentAwakeSystem : AwakeSystem<InventoryComponent>
    {
        public override void Awake(InventoryComponent self)
        {

        }
    }

    [ObjectSystem]
    public class ItemComponentDestorySystem : DestroySystem<InventoryComponent>
    {
        public override void Destroy(InventoryComponent self)
        {

        }
    }

    public static class ItemComponentEx
    {
        public static void Add(this InventoryComponent self, Item item,int pos)
        {
            if (item.Parent != self)
                item.Parent = self;
            self.EmptyPos.Remove(pos);

            if (!self.ConfigId2Items.ContainsKey(item.ItemConfigId))
            {
                self.ConfigId2Items[item.ItemConfigId] = new HashSet<Item>();
            }
            self.ConfigId2Items[item.ItemConfigId].Add(item);
            self.Pos2Item[pos] = item;
            
            Game.EventSystem.Run(new EventIdType.InventoryAdd() { scene = self.DomainScene(), Pos = item.Pos, Item = item }).Coroutine();
        }

        public static void Add(this InventoryComponent self, Item item)
        {
            var pos = self.EmptyPos.First();
            self.Add(item,pos);
        }
        
        public static void Remove(this InventoryComponent self, long itemId, bool dispose = true)
        {
            var item = self.Get(itemId);
            if (item == null) return;
            self.ConfigId2Items[item.ItemConfigId].Remove(item);
            self.Pos2Item.Remove(item.Pos);
            self.EmptyPos.Add(item.Pos);
            Game.EventSystem.Run(new EventIdType.InventoryRemove() { scene = self.DomainScene(), Pos = item.Pos, Item = item }).Coroutine();
            
            if (dispose) item.Dispose();
        }

        public static Item Get(this InventoryComponent self, long itemId)
        {
            self.Children.TryGetValue(itemId, out var item);
            return item as Item;
        }
        
        public static Item GetByPos(this InventoryComponent self, int pos)
        {
            self.Pos2Item.TryGetValue(pos, out var item);
            return item;
        }
    }
}
