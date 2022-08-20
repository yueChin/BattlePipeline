using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class LanguageConfigCategory : ProtoObject
    {
        public static LanguageConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, LanguageConfig> dict = new Dictionary<int, LanguageConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<LanguageConfig> list = new List<LanguageConfig>();
		
        public LanguageConfigCategory()
        {
            Instance = this;
        }
		
		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            foreach (LanguageConfig config in list)
            {
                this.dict.Add(config.Id, config);
            }
            list.Clear();
            this.EndInit();
        }
		
        public LanguageConfig Get(int id)
        {
            this.dict.TryGetValue(id, out LanguageConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (LanguageConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, LanguageConfig> GetAll()
        {
            return this.dict;
        }

        public LanguageConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class LanguageConfig: ProtoObject, IConfig
	{
		[ProtoMember(1, IsRequired  = true)]
		public int Id { get; set; }
		[ProtoMember(2, IsRequired  = true)]
		public string Value_CN { get; set; }


		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            this.EndInit();
        }
	}
}
