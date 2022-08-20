using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class QuestConfigCategory : ProtoObject
    {
        public static QuestConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, QuestConfig> dict = new Dictionary<int, QuestConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<QuestConfig> list = new List<QuestConfig>();
		
        public QuestConfigCategory()
        {
            Instance = this;
        }
		
		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            foreach (QuestConfig config in list)
            {
                this.dict.Add(config.Id, config);
            }
            list.Clear();
            this.EndInit();
        }
		
        public QuestConfig Get(int id)
        {
            this.dict.TryGetValue(id, out QuestConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (QuestConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, QuestConfig> GetAll()
        {
            return this.dict;
        }

        public QuestConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class QuestConfig: ProtoObject, IConfig
	{
		[ProtoMember(1, IsRequired  = true)]
		public int Id { get; set; }
		[ProtoMember(3, IsRequired  = true)]
		public string Name { get; set; }
		[ProtoMember(4, IsRequired  = true)]
		public string Desc { get; set; }
		[ProtoMember(5, IsRequired  = true)]
		public int QuestType { get; set; }
		[ProtoMember(6, IsRequired  = true)]
		public int[] QuestContent { get; set; }
		[ProtoMember(7, IsRequired  = true)]
		public int NextQuest { get; set; }
		[ProtoMember(8, IsRequired  = true)]
		public int TriggerPlot { get; set; }
		[ProtoMember(9, IsRequired  = true)]
		public int QuestAward_Exp { get; set; }
		[ProtoMember(10, IsRequired  = true)]
		public int QuestAward_Money { get; set; }
		[ProtoMember(11, IsRequired  = true)]
		public int[] QuestAward_ItemIds { get; set; }
		[ProtoMember(12, IsRequired  = true)]
		public int[] QuestAward_ItemNums { get; set; }


		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            this.EndInit();
        }
	}
}
