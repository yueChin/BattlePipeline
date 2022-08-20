using System.Runtime.InteropServices;

namespace ET
{
    public class SpellCastChildNodeHandler : ANodeHandler<SpellCastChildNode>
    {
        public override async ETTask<bool> Run(SpellCastChildNode node, BTEnv env)
        {
            var spell = env.Get<Spell>(node.Spell);
            var unit = spell.Caster;
            var buff = unit.GetComponent<BuffComponent>().GetOneByConfigId(node.FlagBuffId);
            int buffStack = 0;
            if (buff != null)
                buffStack = buff.stack;
            var childSpellId = node.SpellConfigIds[buffStack];
            Log.Debug("准备释放子技能" + childSpellId);
            var childSpell = SpellFactory.CreateChild(spell, childSpellId);
            SpellHelper.CastChild(childSpell);
            if (buff != null)
            {
                if (buff.stack < buff.BuffConfig.MaxStack)
                    BuffFactory.CreateAndAdd(unit, unit, node.FlagBuffId);
                else
                    unit.GetComponent<BuffComponent>().Remove(buff.Id);
            }
            else
            {
                BuffFactory.CreateAndAdd(unit, unit, node.FlagBuffId);
            }

            await ETTask.CompletedTask;
            return true;
        }
    }
}