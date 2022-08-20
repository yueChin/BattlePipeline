using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class Spell : Entity
    {
        public int SpellConfigId;
        public SpellConfig SpellConfig
        {
            get => SpellConfigCategory.Instance.Get(SpellConfigId);
        }

        public Unit Caster;

        public Spell Child;

        public ETTask task = ETTask.Create();

        public override void Dispose()
        {
            Log.Debug("技能结束  "+ this.SpellConfigId);
            var task = this.task;
            this.task = null;
            task?.SetResult();
            this.Caster?.GetComponent<SpellComponent>()?.CurrUsing.Remove(this.SpellConfigId);
            base.Dispose();
        }
    }
}
