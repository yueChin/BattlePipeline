using System.Collections.Generic;

namespace ET
{
    public class SpellCastEffect2TargetsNodeHandler : ANodeHandler<SpellCastEffect2TargetsNode>
    {
        public override async ETTask<bool> Run(SpellCastEffect2TargetsNode node, BTEnv env)
        {
            var spell = env.Get<Spell>(node.Spell);
            var targets = env.Get<List<long>>(node.Targets);
            if (targets == null)
                return false;
            var com = spell.Caster.Domain.GetComponent<UnitComponent>();
            foreach (var v in targets)
            {
                var tar = com.Get(v);
                if (tar.IsDisposed || !tar.GetAlive())
                {
                    continue;
                }

                using var effect = EffectFactory.Create(spell, node.EffectId);
                effect.Target = tar;
                EffectEventMgrComponent.Instance.Handle(EffectTriggerType.SpellHit,effect);
            }

            await ETTask.CompletedTask;
            return true;
        }
    }
}