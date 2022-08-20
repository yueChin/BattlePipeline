using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    public class InventoryComponent : Entity
    {

        //用SortedDictionary的目的是希望根据configId排序
        [BsonIgnore]
        public SortedDictionary<int, HashSet<Item>> ConfigId2Items = new SortedDictionary<int, HashSet<Item>>();

        public Dictionary<int, Item> Pos2Item = new Dictionary<int, Item>();
        public HashSet<int> EmptyPos = new HashSet<int>();

        public const int MaxItem = 50; // 暂时先这样吧,后续看情况再改
    }
}
