using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class BuffTypeConfigCategory : ProtoObject
    {
        public static BuffTypeConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, BuffTypeConfig> dict = new Dictionary<int, BuffTypeConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<BuffTypeConfig> list = new List<BuffTypeConfig>();
		
        public BuffTypeConfigCategory()
        {
            Instance = this;
        }
		
		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            foreach (BuffTypeConfig config in list)
            {
                this.dict.Add(config.Id, config);
            }
            list.Clear();
            this.EndInit();
        }
		
        public BuffTypeConfig Get(int id)
        {
            this.dict.TryGetValue(id, out BuffTypeConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (BuffTypeConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, BuffTypeConfig> GetAll()
        {
            return this.dict;
        }

        public BuffTypeConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class BuffTypeConfig: ProtoObject, IConfig
	{
		[ProtoMember(1, IsRequired  = true)]
		public int Id { get; set; }
		[ProtoMember(3, IsRequired  = true)]
		public int Flag { get; set; }
		[ProtoMember(4, IsRequired  = true)]
		public int[] TypeImmune { get; set; }
		[ProtoMember(5, IsRequired  = true)]
		public int[] TypeDispelled { get; set; }


		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            this.EndInit();
        }
	}
}
