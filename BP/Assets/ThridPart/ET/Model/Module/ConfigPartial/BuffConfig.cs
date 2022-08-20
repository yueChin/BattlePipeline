using System.Collections.Generic;

namespace ET
{
    public partial class BuffConfigCategory
    {
        public Dictionary<(int buffConfigId, int triggerType), HashSet<int>> AllEffects =
            new Dictionary<(int, int), HashSet<int>>();

        public override void EndInit()
        {
            base.EndInit();
            AllEffects.Clear();
            foreach (var v in this.dict)
            {
                if(v.Value.Effects == null||v.Value.Effects.Length == 0)
                    continue;
                var effects = v.Value.Effects;
                for (int i = 0; i < effects.Length; i+=2)
                {
                    var triggerType = effects[i];
                    var effect = effects[i + 1];
                    var key = (v.Key, triggerType);
                    if (!AllEffects.ContainsKey(key))
                        AllEffects[key] = new HashSet<int>();
                    AllEffects[key].Add(effect);
                }
            }
        }
        
        public HashSet<int> GetByTriggerType(int configId,EffectTriggerType triggerType)
        {
            AllEffects.TryGetValue((configId, (int) triggerType), out var ret);
            return ret;
        }
    }
}