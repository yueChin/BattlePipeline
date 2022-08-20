using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class SpellConfigCategory : ProtoObject
    {
        public static SpellConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, SpellConfig> dict = new Dictionary<int, SpellConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<SpellConfig> list = new List<SpellConfig>();
		
        public SpellConfigCategory()
        {
            Instance = this;
        }
		
		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            foreach (SpellConfig config in list)
            {
                this.dict.Add(config.Id, config);
            }
            list.Clear();
            this.EndInit();
        }
		
        public SpellConfig Get(int id)
        {
            this.dict.TryGetValue(id, out SpellConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (SpellConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, SpellConfig> GetAll()
        {
            return this.dict;
        }

        public SpellConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class SpellConfig: ProtoObject, IConfig
	{
		[ProtoMember(1, IsRequired  = true)]
		public int Id { get; set; }
		[ProtoMember(3, IsRequired  = true)]
		public string Desc { get; set; }
		[ProtoMember(4, IsRequired  = true)]
		public bool CanUseInSpellState { get; set; }
		[ProtoMember(5, IsRequired  = true)]
		public int SpellStateDuration { get; set; }
		[ProtoMember(6, IsRequired  = true)]
		public int StopMoveDuration { get; set; }
		[ProtoMember(7, IsRequired  = true)]
		public int ColdDown { get; set; }
		[ProtoMember(8, IsRequired  = true)]
		public string BTConfigName { get; set; }
		[ProtoMember(9, IsRequired  = true)]
		public int UpdateInterval { get; set; }
		[ProtoMember(10, IsRequired  = true)]
		public string ExtendAnim { get; set; }


		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            this.EndInit();
        }
	}
}
