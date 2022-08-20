using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class BuffConfigCategory : ProtoObject
    {
        public static BuffConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, BuffConfig> dict = new Dictionary<int, BuffConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<BuffConfig> list = new List<BuffConfig>();
		
        public BuffConfigCategory()
        {
            Instance = this;
        }
		
		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            foreach (BuffConfig config in list)
            {
                this.dict.Add(config.Id, config);
            }
            list.Clear();
            this.EndInit();
        }
		
        public BuffConfig Get(int id)
        {
            this.dict.TryGetValue(id, out BuffConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (BuffConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, BuffConfig> GetAll()
        {
            return this.dict;
        }

        public BuffConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class BuffConfig: ProtoObject, IConfig
	{
		[ProtoMember(1, IsRequired  = true)]
		public int Id { get; set; }
		[ProtoMember(3, IsRequired  = true)]
		public string Name { get; set; }
		[ProtoMember(4, IsRequired  = true)]
		public string Desc { get; set; }
		[ProtoMember(5, IsRequired  = true)]
		public int Duration { get; set; }
		[ProtoMember(6, IsRequired  = true)]
		public int MaxStack { get; set; }
		[ProtoMember(7, IsRequired  = true)]
		public int[] Effects { get; set; }
		[ProtoMember(8, IsRequired  = true)]
		public int TickSpan { get; set; }
		[ProtoMember(9, IsRequired  = true)]
		public int BuffType { get; set; }
		[ProtoMember(10, IsRequired  = true)]
		public int RepeatAdd { get; set; }
		[ProtoMember(11, IsRequired  = true)]
		public int[] BuffRemoveCond { get; set; }


		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            this.EndInit();
        }
	}
}
