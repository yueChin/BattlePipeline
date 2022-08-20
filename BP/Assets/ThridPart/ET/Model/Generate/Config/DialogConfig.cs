using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class DialogConfigCategory : ProtoObject
    {
        public static DialogConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, DialogConfig> dict = new Dictionary<int, DialogConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<DialogConfig> list = new List<DialogConfig>();
		
        public DialogConfigCategory()
        {
            Instance = this;
        }
		
		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            foreach (DialogConfig config in list)
            {
                this.dict.Add(config.Id, config);
            }
            list.Clear();
            this.EndInit();
        }
		
        public DialogConfig Get(int id)
        {
            this.dict.TryGetValue(id, out DialogConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (DialogConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, DialogConfig> GetAll()
        {
            return this.dict;
        }

        public DialogConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class DialogConfig: ProtoObject, IConfig
	{
		[ProtoMember(1, IsRequired  = true)]
		public int Id { get; set; }
		[ProtoMember(2, IsRequired  = true)]
		public string Content { get; set; }
		[ProtoMember(3, IsRequired  = true)]
		public int DisplayType { get; set; }
		[ProtoMember(4, IsRequired  = true)]
		public int Status { get; set; }
		[ProtoMember(5, IsRequired  = true)]
		public int EndEffect { get; set; }
		[ProtoMember(6, IsRequired  = true)]
		public int[] EndEffectParam { get; set; }
		[ProtoMember(7, IsRequired  = true)]
		public int[] Option { get; set; }


		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            this.EndInit();
        }
	}
}
