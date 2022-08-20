using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public static class SpellFactory
    {
        public static Spell SimpleCreate(Unit caster, int spellConfigId)
        {
            var spellCom = caster.GetComponent<SpellComponent>();
            var spell = EntityFactory.CreateWithParent<Spell>(spellCom);
            spell.SpellConfigId = spellConfigId;
            spell.Caster = caster;
            return spell;
        }

        public static Spell CreateChild(Spell parent, int spellConfigId)
        {
            var spell = EntityFactory.CreateWithParent<Spell>(parent);
            spell.SpellConfigId = spellConfigId;
            parent.Child = spell;
            spell.Caster = parent.Caster;
            return spell;
        }

        public static Spell CreateWithTargets(Unit caster, int spellConfigId, List<long> targets)
        {
            var spell = SimpleCreate(caster, spellConfigId);
            spell.AddComponent<TargetsComponent>().TargetsInstanceId.AddRange(targets);
            return spell;
        }

        public static Spell CreateWithLockTarget(Unit caster, int spellConfigId, Unit target)
        {
            var spell = SimpleCreate(caster, spellConfigId);
            spell.AddComponent<LockTargetComponent>().target = target ;
            return spell;
        }
    }
}
