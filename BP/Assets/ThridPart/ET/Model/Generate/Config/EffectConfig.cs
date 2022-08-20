using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class EffectConfigCategory : ProtoObject
    {
        public static EffectConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, EffectConfig> dict = new Dictionary<int, EffectConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<EffectConfig> list = new List<EffectConfig>();
		
        public EffectConfigCategory()
        {
            Instance = this;
        }
		
		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            foreach (EffectConfig config in list)
            {
                this.dict.Add(config.Id, config);
            }
            list.Clear();
            this.EndInit();
        }
		
        public EffectConfig Get(int id)
        {
            this.dict.TryGetValue(id, out EffectConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (EffectConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, EffectConfig> GetAll()
        {
            return this.dict;
        }

        public EffectConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class EffectConfig: ProtoObject, IConfig
	{
		[ProtoMember(1, IsRequired  = true)]
		public int Id { get; set; }
		[ProtoMember(2, IsRequired  = true)]
		public int EffectType { get; set; }
		[ProtoMember(3, IsRequired  = true)]
		public int[] EffectParams { get; set; }


		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            this.EndInit();
        }
	}
}
