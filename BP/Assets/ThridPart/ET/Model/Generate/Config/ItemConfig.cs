using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class ItemConfigCategory : ProtoObject
    {
        public static ItemConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, ItemConfig> dict = new Dictionary<int, ItemConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<ItemConfig> list = new List<ItemConfig>();
		
        public ItemConfigCategory()
        {
            Instance = this;
        }
		
		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            foreach (ItemConfig config in list)
            {
                this.dict.Add(config.Id, config);
            }
            list.Clear();
            this.EndInit();
        }
		
        public ItemConfig Get(int id)
        {
            this.dict.TryGetValue(id, out ItemConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (ItemConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, ItemConfig> GetAll()
        {
            return this.dict;
        }

        public ItemConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class ItemConfig: ProtoObject, IConfig
	{
		[ProtoMember(1, IsRequired  = true)]
		public int Id { get; set; }
		[ProtoMember(3, IsRequired  = true)]
		public string Name { get; set; }
		[ProtoMember(4, IsRequired  = true)]
		public string Res { get; set; }
		[ProtoMember(5, IsRequired  = true)]
		public int DropUnitConfigId { get; set; }
		[ProtoMember(6, IsRequired  = true)]
		public string Desc { get; set; }
		[ProtoMember(7, IsRequired  = true)]
		public int ItemClass { get; set; }
		[ProtoMember(8, IsRequired  = true)]
		public int ItemType { get; set; }
		[ProtoMember(9, IsRequired  = true)]
		public int MaxAddNum { get; set; }
		[ProtoMember(10, IsRequired  = true)]
		public int EquipPoint { get; set; }
		[ProtoMember(11, IsRequired  = true)]
		public string BasePlot { get; set; }
		[ProtoMember(12, IsRequired  = true)]
		public string Model { get; set; }
		[ProtoMember(13, IsRequired  = true)]
		public int ModelBindPoint { get; set; }
		[ProtoMember(14, IsRequired  = true)]
		public int[] InitSpells { get; set; }


		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            this.EndInit();
        }
	}
}
