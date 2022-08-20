using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class UnitConfigCategory : ProtoObject
    {
        public static UnitConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, UnitConfig> dict = new Dictionary<int, UnitConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<UnitConfig> list = new List<UnitConfig>();
		
        public UnitConfigCategory()
        {
            Instance = this;
        }
		
		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            foreach (UnitConfig config in list)
            {
                this.dict.Add(config.Id, config);
            }
            list.Clear();
            this.EndInit();
        }
		
        public UnitConfig Get(int id)
        {
            this.dict.TryGetValue(id, out UnitConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (UnitConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, UnitConfig> GetAll()
        {
            return this.dict;
        }

        public UnitConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class UnitConfig: ProtoObject, IConfig
	{
		[ProtoMember(1, IsRequired  = true)]
		public int Id { get; set; }
		[ProtoMember(3, IsRequired  = true)]
		public string Name { get; set; }
		[ProtoMember(4, IsRequired  = true)]
		public string Res { get; set; }
		[ProtoMember(5, IsRequired  = true)]
		public string Desc { get; set; }
		[ProtoMember(6, IsRequired  = true)]
		public int UnitType { get; set; }
		[ProtoMember(7, IsRequired  = true)]
		public int Radius { get; set; }
		[ProtoMember(8, IsRequired  = true)]
		public bool JoinBattle { get; set; }
		[ProtoMember(9, IsRequired  = true)]
		public bool CanMove { get; set; }
		[ProtoMember(10, IsRequired  = true)]
		public int AIConfig { get; set; }
		[ProtoMember(11, IsRequired  = true)]
		public int[] InitSpells { get; set; }
		[ProtoMember(12, IsRequired  = true)]
		public int HPRefix { get; set; }
		[ProtoMember(13, IsRequired  = true)]
		public int ATKRefix { get; set; }
		[ProtoMember(14, IsRequired  = true)]
		public int PDEFRefix { get; set; }
		[ProtoMember(15, IsRequired  = true)]
		public int MDEFRefix { get; set; }
		[ProtoMember(16, IsRequired  = true)]
		public int MoveSpeedRefix { get; set; }
		[ProtoMember(17, IsRequired  = true)]
		public int HPRecoverRefix { get; set; }
		[ProtoMember(18, IsRequired  = true)]
		public int DropItemId { get; set; }
		[ProtoMember(19, IsRequired  = true)]
		public int TransferConfig { get; set; }


		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            this.EndInit();
        }
	}
}
