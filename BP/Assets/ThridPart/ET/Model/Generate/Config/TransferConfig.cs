using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class TransferConfigCategory : ProtoObject
    {
        public static TransferConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, TransferConfig> dict = new Dictionary<int, TransferConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<TransferConfig> list = new List<TransferConfig>();
		
        public TransferConfigCategory()
        {
            Instance = this;
        }
		
		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            foreach (TransferConfig config in list)
            {
                this.dict.Add(config.Id, config);
            }
            list.Clear();
            this.EndInit();
        }
		
        public TransferConfig Get(int id)
        {
            this.dict.TryGetValue(id, out TransferConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (TransferConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, TransferConfig> GetAll()
        {
            return this.dict;
        }

        public TransferConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class TransferConfig: ProtoObject, IConfig
	{
		[ProtoMember(1, IsRequired  = true)]
		public int Id { get; set; }
		[ProtoMember(3, IsRequired  = true)]
		public int TargetMap { get; set; }
		[ProtoMember(4, IsRequired  = true)]
		public int InitPos { get; set; }
		[ProtoMember(5, IsRequired  = true)]
		public int TransferType { get; set; }


		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            this.EndInit();
        }
	}
}
