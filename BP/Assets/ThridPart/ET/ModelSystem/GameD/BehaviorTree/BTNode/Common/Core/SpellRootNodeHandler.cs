using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [BehaviorTree]
    public class SpellRootNodeHandler : ANodeHandler<SpellRootNode>
    {
        public override async ETTask<bool> Run(SpellRootNode node, BTEnv env)
        {

            Spell _s = env.Get<Entity>(BTEnvKey.Entity) as Spell;
            if (_s == null)
            {
                Log.Error("SpellRoot错误,无法转换为Spell");
                return false;
            }
            env.Add<Spell>(BTEnvKey.Spell, _s);
            env.Add<Unit>(node.SpellCaster, _s.Caster);
            if(_s.GetComponent<AttackerComponent>() != null)
                env.Add<Unit>(node.SpellAttacker, _s.GetComponent<AttackerComponent>().Attacker);

            foreach (var v in node.Children)
            {
                await BTHelper.RunNode(v, env);
            }
            return true;
        }
    
    }
}
