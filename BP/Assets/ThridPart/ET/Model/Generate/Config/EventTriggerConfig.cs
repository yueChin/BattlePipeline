using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class EventTriggerConfigCategory : ProtoObject
    {
        public static EventTriggerConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, EventTriggerConfig> dict = new Dictionary<int, EventTriggerConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<EventTriggerConfig> list = new List<EventTriggerConfig>();
		
        public EventTriggerConfigCategory()
        {
            Instance = this;
        }
		
		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            foreach (EventTriggerConfig config in list)
            {
                this.dict.Add(config.Id, config);
            }
            list.Clear();
            this.EndInit();
        }
		
        public EventTriggerConfig Get(int id)
        {
            this.dict.TryGetValue(id, out EventTriggerConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (EventTriggerConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, EventTriggerConfig> GetAll()
        {
            return this.dict;
        }

        public EventTriggerConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class EventTriggerConfig: ProtoObject, IConfig
	{
		[ProtoMember(1, IsRequired  = true)]
		public int Id { get; set; }
		[ProtoMember(3, IsRequired  = true)]
		public string Express { get; set; }
		[ProtoMember(4, IsRequired  = true)]
		public int EffectType { get; set; }
		[ProtoMember(5, IsRequired  = true)]
		public int[] EffectParams { get; set; }


		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            this.EndInit();
        }
	}
}
