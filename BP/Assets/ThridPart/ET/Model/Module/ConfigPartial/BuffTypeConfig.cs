using System.Collections.Generic;

namespace ET
{
    public partial class BuffTypeConfigCategory
    {
        public Dictionary<int, HashSet<int>> Flag2Types = new Dictionary<int, HashSet<int>>();

        public override void EndInit()
        {
            base.EndInit();
            foreach (var v in this.dict)
            {
                if (!Flag2Types.ContainsKey(v.Value.Flag))
                    Flag2Types[v.Value.Flag] = new HashSet<int>();
                Flag2Types[v.Value.Flag].Add(v.Value.Id);
            }
        }
    }
}