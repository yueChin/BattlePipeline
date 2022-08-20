using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class MapConfigCategory : ProtoObject
    {
        public static MapConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, MapConfig> dict = new Dictionary<int, MapConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<MapConfig> list = new List<MapConfig>();
		
        public MapConfigCategory()
        {
            Instance = this;
        }
		
		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            foreach (MapConfig config in list)
            {
                this.dict.Add(config.Id, config);
            }
            list.Clear();
            this.EndInit();
        }
		
        public MapConfig Get(int id)
        {
            this.dict.TryGetValue(id, out MapConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (MapConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, MapConfig> GetAll()
        {
            return this.dict;
        }

        public MapConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class MapConfig: ProtoObject, IConfig
	{
		[ProtoMember(1, IsRequired  = true)]
		public int Id { get; set; }
		[ProtoMember(3, IsRequired  = true)]
		public string SceneName { get; set; }
		[ProtoMember(4, IsRequired  = true)]
		public string Desc { get; set; }
		[ProtoMember(5, IsRequired  = true)]
		public string Asset { get; set; }
		[ProtoMember(6, IsRequired  = true)]
		public int CopyType { get; set; }
		[ProtoMember(7, IsRequired  = true)]
		public string PointConfig { get; set; }
		[ProtoMember(8, IsRequired  = true)]
		public int LvType { get; set; }
		[ProtoMember(9, IsRequired  = true)]
		public int[] LvParams { get; set; }


		[ProtoAfterDeserialization]
        public void AfterDeserialization()
        {
            this.EndInit();
        }
	}
}
