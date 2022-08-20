using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class LevelNumericConfigCategory : ProtoObject
    {
        public static LevelNumericConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, LevelNumericConfig> dict = new Dictionary<int, LevelNumericConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<LevelNumericConfig> list = new List<LevelNumericConfig>();
		
        public LevelNumericConfigCategory()
        {
            Instance = this;
        }
		
		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            foreach (LevelNumericConfig config in list)
            {
                this.dict.Add(config.Id, config);
            }
            list.Clear();
            this.EndInit();
        }
		
        public LevelNumericConfig Get(int id)
        {
            this.dict.TryGetValue(id, out LevelNumericConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (LevelNumericConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, LevelNumericConfig> GetAll()
        {
            return this.dict;
        }

        public LevelNumericConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class LevelNumericConfig: ProtoObject, IConfig
	{
		[ProtoMember(1, IsRequired  = true)]
		public int Id { get; set; }
		[ProtoMember(2, IsRequired  = true)]
		public int[] NumericKeys { get; set; }


		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            this.EndInit();
        }
	}
}
