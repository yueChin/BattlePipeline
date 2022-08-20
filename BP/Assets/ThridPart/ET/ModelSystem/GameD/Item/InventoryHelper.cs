using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public static class InventoryHelper
    {
        public static bool CheckIfFull(this InventoryComponent itemCom,int addCount = 0)
        {
            if (itemCom.Children.Count + addCount >= InventoryComponent.MaxItem)
            {
                return true;
            }
            return false;
        }

        public static int AddNewItem(Entity myUnit, int configId, int num)
        {
            return AddNewItem(myUnit.GetComponent<InventoryComponent>(), configId, num);
        }

        //不管有没有旧的,都创建一个新的
        public static int AddNewItem(InventoryComponent itemCom, int configId, int num)
        {
            Item item = null;
            if (itemCom.CheckIfFull())
            {
                return ErrorCode.ERR_AgentMax; //todo： 提示背包空间满了
            }
            // 计算需要分割成几份
            var config = ItemConfigCategory.Instance.Get(configId);
            if (num <= config.MaxAddNum)
            {
                // 不需要分割,直接加就完事了
                item = ItemFactory.Create(itemCom.Domain as Scene, configId, num);
                itemCom.Add(item);
                return 0;
            }
            int splitCount = num / config.MaxAddNum;
            int lastNum = num % config.MaxAddNum;
            if (lastNum != 0) splitCount++;
            else lastNum = config.MaxAddNum;
            if (itemCom.CheckIfFull(splitCount))
            {
                return ErrorCode.ERR_AgentMax; //todo: 背包空间不足
            }
            for (int i = 0; i < splitCount - 1; i++)
            {
                item = ItemFactory.Create(itemCom.Domain as Scene, configId, config.MaxAddNum);
                itemCom.Add(item);
            }
            item = ItemFactory.Create(itemCom.Domain as Scene, configId, lastNum);
            itemCom.Add(item);
            return 0;
        }

        // 先尝试给旧的增加数量,不行再创建新的
        public static int AddNum(InventoryComponent itemCom, int configId, int num)
        {
            if (!itemCom.ConfigId2Items.TryGetValue(configId, out var oldItems))
            {
                return AddNewItem(itemCom, configId, num);
            }
            Item item = null;
            foreach (var v in oldItems)
            {
                if (v.Num >= v.ItemConfig.MaxAddNum) continue;
                item = v;
                break;
            }
            if (item == null)
            {
                return AddNewItem(itemCom, configId, num);
            }
            // 数量较少,一个旧的就装得下
            int needHandleNum = num + item.Num - item.ItemConfig.MaxAddNum ;
            if (needHandleNum <= 0)
            {
                item.Num += num;
                return 0;
            }
            //先暂时这样判断空间是否足够
            int splitCount = needHandleNum / item.ItemConfig.MaxAddNum;
            int lastNum = needHandleNum % item.ItemConfig.MaxAddNum;
            if (lastNum != 0) splitCount++;
            else lastNum = item.ItemConfig.MaxAddNum;
            if (itemCom.CheckIfFull(splitCount))
            {
                return ErrorCode.ERR_AgentMax;//todo: 提示空间不足
            }

            item.Num = item.ItemConfig.MaxAddNum;
            return AddNewItem(itemCom, configId, needHandleNum);
        }

        public static int GetNum(InventoryComponent inventoryComponent, int itemConfigId)
        {
            if (!inventoryComponent.ConfigId2Items.TryGetValue(itemConfigId, out var oldItems))
            {
                return 0;
            }
            int num = 0;
            foreach (var v in oldItems)
                num += v.Num;
            return num;
        }

        // 如果Item已经存在,比如邮件或者副本奖励之类的
        public static bool AddItem(InventoryComponent itemCom, Item item)
        {
            if (itemCom.CheckIfFull(1))
            {
                return false;
            }
            itemCom.Add(item);
            return true;
        }

        public static bool RemoveItem(InventoryComponent itemCom, int configId, int num,out int removeNum,bool costToMax = false)
        {
            removeNum = 0;
            if (!itemCom.ConfigId2Items.TryGetValue(configId, out var oldItems))
            {
                return false;
            }
            int totalNum = oldItems.Sum(v => v.Num);
            Log.Debug($"Remove: {configId} Count: {num} Total: {totalNum}");
            int rest = num;
            if (!costToMax)
            {
                if (totalNum < num) return false;
                rest = num;
                removeNum = num;
            }
            else
            {
                if (totalNum == 0) return false;
                removeNum = num;
                if (totalNum < num)
                {
                    rest = totalNum;
                    removeNum = totalNum;
                }
            }


            using (var deleteSet = HashSetComponent<long>.Create())
            {
                foreach (var v in oldItems)
                {
                    if (v.Num < rest)
                    {
                        deleteSet.Set.Add(v.Id);
                        rest -= v.Num;
                        continue;
                    }

                    if (v.Num == rest)
                    {
                        deleteSet.Set.Add(v.Id);
                        rest -= v.Num;
                        break;
                    }

                    if (v.Num > rest)
                    {
                        v.Num -= rest;
                        rest = 0;
                        break;
                    }

                }

                foreach (var v in deleteSet.Set)
                {
                    itemCom.Remove(v);
                }
            }

            return true;
        }


        public static async ETTask Discard(InventoryComponent itemCom, long itemId)
        {
            var req = new C2M_DiscardItem() { ItemId = itemId,Pos = itemCom.GetMyUnit().Position.ToProto()};
            var resp = await itemCom.CurrSession().Call(req);
        }

        public static async ETTask PutOnEquip(InventoryComponent itemCom, Item item)
        {
            if (item.ItemConfig.ItemClass != (int) ItemClass.Equip)
            {
                return;
            }

            var req = new C2M_PutOnEquip() { EquipPoint = item.ItemConfig.EquipPoint, ItemId = item.Id };
            var resp = await itemCom.CurrSession().Call(req);

        }

        public static async ETTask PutDownEquip(EquipComponent com, int EquipPointType)
        {
            if (!com.AllEquips.ContainsKey(EquipPointType))
                return;
            var req = new C2M_PutDownEquip() { EquipPoint = EquipPointType };
            var resp = await com.CurrSession().Call(req);
        }

    }
}
