using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class PlotConfigCategory : ProtoObject
    {
        public static PlotConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, PlotConfig> dict = new Dictionary<int, PlotConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<PlotConfig> list = new List<PlotConfig>();
		
        public PlotConfigCategory()
        {
            Instance = this;
        }
		
		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            foreach (PlotConfig config in list)
            {
                this.dict.Add(config.Id, config);
            }
            list.Clear();
            this.EndInit();
        }
		
        public PlotConfig Get(int id)
        {
            this.dict.TryGetValue(id, out PlotConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (PlotConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, PlotConfig> GetAll()
        {
            return this.dict;
        }

        public PlotConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class PlotConfig: ProtoObject, IConfig
	{
		[ProtoMember(1, IsRequired  = true)]
		public int Id { get; set; }
		[ProtoMember(2, IsRequired  = true)]
		public bool UseBT { get; set; }
		[ProtoMember(3, IsRequired  = true)]
		public int[] DialogQueue { get; set; }


		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            this.EndInit();
        }
	}
}
