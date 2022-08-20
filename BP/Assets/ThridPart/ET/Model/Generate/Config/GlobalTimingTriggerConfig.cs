using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class GlobalTimingTriggerConfigCategory : ProtoObject
    {
        public static GlobalTimingTriggerConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, GlobalTimingTriggerConfig> dict = new Dictionary<int, GlobalTimingTriggerConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<GlobalTimingTriggerConfig> list = new List<GlobalTimingTriggerConfig>();
		
        public GlobalTimingTriggerConfigCategory()
        {
            Instance = this;
        }
		
		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            foreach (GlobalTimingTriggerConfig config in list)
            {
                this.dict.Add(config.Id, config);
            }
            list.Clear();
            this.EndInit();
        }
		
        public GlobalTimingTriggerConfig Get(int id)
        {
            this.dict.TryGetValue(id, out GlobalTimingTriggerConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (GlobalTimingTriggerConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, GlobalTimingTriggerConfig> GetAll()
        {
            return this.dict;
        }

        public GlobalTimingTriggerConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class GlobalTimingTriggerConfig: ProtoObject, IConfig
	{
		[ProtoMember(1, IsRequired  = true)]
		public int Id { get; set; }
		[ProtoMember(3, IsRequired  = true)]
		public int TimeType { get; set; }
		[ProtoMember(4, IsRequired  = true)]
		public string TimeStr { get; set; }


		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            this.EndInit();
        }
	}
}
