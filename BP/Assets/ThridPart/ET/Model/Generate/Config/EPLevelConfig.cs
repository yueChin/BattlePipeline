using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class EPLevelConfigCategory : ProtoObject
    {
        public static EPLevelConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, EPLevelConfig> dict = new Dictionary<int, EPLevelConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<EPLevelConfig> list = new List<EPLevelConfig>();
		
        public EPLevelConfigCategory()
        {
            Instance = this;
        }
		
		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            foreach (EPLevelConfig config in list)
            {
                this.dict.Add(config.Id, config);
            }
            list.Clear();
            this.EndInit();
        }
		
        public EPLevelConfig Get(int id)
        {
            this.dict.TryGetValue(id, out EPLevelConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (EPLevelConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, EPLevelConfig> GetAll()
        {
            return this.dict;
        }

        public EPLevelConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class EPLevelConfig: ProtoObject, IConfig
	{
		[ProtoMember(1, IsRequired  = true)]
		public int Id { get; set; }
		[ProtoMember(3, IsRequired  = true)]
		public int[] Path { get; set; }
		[ProtoMember(4, IsRequired  = true)]
		public int[] EndPointWaveConfig { get; set; }
		[ProtoMember(5, IsRequired  = true)]
		public int[] EndPointWaveInterval { get; set; }


		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            this.EndInit();
        }
	}
}
