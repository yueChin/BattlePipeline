using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class NumericTypeConfigCategory : ProtoObject
    {
        public static NumericTypeConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, NumericTypeConfig> dict = new Dictionary<int, NumericTypeConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<NumericTypeConfig> list = new List<NumericTypeConfig>();
		
        public NumericTypeConfigCategory()
        {
            Instance = this;
        }
		
		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            foreach (NumericTypeConfig config in list)
            {
                this.dict.Add(config.Id, config);
            }
            list.Clear();
            this.EndInit();
        }
		
        public NumericTypeConfig Get(int id)
        {
            this.dict.TryGetValue(id, out NumericTypeConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (NumericTypeConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, NumericTypeConfig> GetAll()
        {
            return this.dict;
        }

        public NumericTypeConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class NumericTypeConfig: ProtoObject, IConfig
	{
		[ProtoMember(1, IsRequired  = true)]
		public int Id { get; set; }
		[ProtoMember(2, IsRequired  = true)]
		public int MaxNum { get; set; }


		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            this.EndInit();
        }
	}
}
