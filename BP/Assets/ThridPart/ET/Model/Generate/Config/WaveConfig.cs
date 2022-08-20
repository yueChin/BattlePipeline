using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class WaveConfigCategory : ProtoObject
    {
        public static WaveConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, WaveConfig> dict = new Dictionary<int, WaveConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<WaveConfig> list = new List<WaveConfig>();
		
        public WaveConfigCategory()
        {
            Instance = this;
        }
		
		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            foreach (WaveConfig config in list)
            {
                this.dict.Add(config.Id, config);
            }
            list.Clear();
            this.EndInit();
        }
		
        public WaveConfig Get(int id)
        {
            this.dict.TryGetValue(id, out WaveConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (WaveConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, WaveConfig> GetAll()
        {
            return this.dict;
        }

        public WaveConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class WaveConfig: ProtoObject, IConfig
	{
		[ProtoMember(1, IsRequired  = true)]
		public int Id { get; set; }
		[ProtoMember(2, IsRequired  = true)]
		public int[] Timer { get; set; }
		[ProtoMember(3, IsRequired  = true)]
		public int[] Nodes { get; set; }
		[ProtoMember(4, IsRequired  = true)]
		public int[] Pos { get; set; }
		[ProtoMember(5, IsRequired  = true)]
		public int Level { get; set; }
		[ProtoMember(6, IsRequired  = true)]
		public int[] AddBuffs { get; set; }


		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            this.EndInit();
        }
	}
}
