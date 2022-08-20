using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class WaveNodeConfigCategory : ProtoObject
    {
        public static WaveNodeConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, WaveNodeConfig> dict = new Dictionary<int, WaveNodeConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<WaveNodeConfig> list = new List<WaveNodeConfig>();
		
        public WaveNodeConfigCategory()
        {
            Instance = this;
        }
		
		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            foreach (WaveNodeConfig config in list)
            {
                this.dict.Add(config.Id, config);
            }
            list.Clear();
            this.EndInit();
        }
		
        public WaveNodeConfig Get(int id)
        {
            this.dict.TryGetValue(id, out WaveNodeConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (WaveNodeConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, WaveNodeConfig> GetAll()
        {
            return this.dict;
        }

        public WaveNodeConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class WaveNodeConfig: ProtoObject, IConfig
	{
		[ProtoMember(1, IsRequired  = true)]
		public int Id { get; set; }
		[ProtoMember(2, IsRequired  = true)]
		public int UnitConfigId { get; set; }
		[ProtoMember(3, IsRequired  = true)]
		public int Num { get; set; }
		[ProtoMember(4, IsRequired  = true)]
		public int Interval { get; set; }


		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            this.EndInit();
        }
	}
}
