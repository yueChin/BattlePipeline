using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class EventCondConfigCategory : ProtoObject
    {
        public static EventCondConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, EventCondConfig> dict = new Dictionary<int, EventCondConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<EventCondConfig> list = new List<EventCondConfig>();
		
        public EventCondConfigCategory()
        {
            Instance = this;
        }
		
		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            foreach (EventCondConfig config in list)
            {
                this.dict.Add(config.Id, config);
            }
            list.Clear();
            this.EndInit();
        }
		
        public EventCondConfig Get(int id)
        {
            this.dict.TryGetValue(id, out EventCondConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (EventCondConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, EventCondConfig> GetAll()
        {
            return this.dict;
        }

        public EventCondConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class EventCondConfig: ProtoObject, IConfig
	{
		[ProtoMember(1, IsRequired  = true)]
		public int Id { get; set; }
		[ProtoMember(2, IsRequired  = true)]
		public int Type { get; set; }
		[ProtoMember(3, IsRequired  = true)]
		public string Op { get; set; }
		[ProtoMember(4, IsRequired  = true)]
		public int Value { get; set; }


		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            this.EndInit();
        }
	}
}
