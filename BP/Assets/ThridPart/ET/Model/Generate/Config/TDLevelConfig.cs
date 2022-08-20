using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class TDLevelConfigCategory : ProtoObject
    {
        public static TDLevelConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, TDLevelConfig> dict = new Dictionary<int, TDLevelConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<TDLevelConfig> list = new List<TDLevelConfig>();
		
        public TDLevelConfigCategory()
        {
            Instance = this;
        }
		
		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            foreach (TDLevelConfig config in list)
            {
                this.dict.Add(config.Id, config);
            }
            list.Clear();
            this.EndInit();
        }
		
        public TDLevelConfig Get(int id)
        {
            this.dict.TryGetValue(id, out TDLevelConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (TDLevelConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, TDLevelConfig> GetAll()
        {
            return this.dict;
        }

        public TDLevelConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class TDLevelConfig: ProtoObject, IConfig
	{
		[ProtoMember(1, IsRequired  = true)]
		public int Id { get; set; }
		[ProtoMember(3, IsRequired  = true)]
		public int[] WaveConfig { get; set; }
		[ProtoMember(4, IsRequired  = true)]
		public int[] WaveInterval { get; set; }
		[ProtoMember(5, IsRequired  = true)]
		public int WaveTimeout { get; set; }


		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            this.EndInit();
        }
	}
}
