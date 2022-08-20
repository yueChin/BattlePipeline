using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ET
{
    public partial class MapConfigCategory
    {
        public Dictionary<string, MapConfig> Name2Config = new Dictionary<string, MapConfig>();
        public override void EndInit()
        {
            base.EndInit();
            Name2Config.Clear();
            foreach (var v in this.dict)
            {
                Name2Config[v.Value.SceneName] = v.Value;
            }
        }

        public MapConfig GetByName(string SceneName)
        {
            return this.Name2Config[SceneName];
        }
    }
}