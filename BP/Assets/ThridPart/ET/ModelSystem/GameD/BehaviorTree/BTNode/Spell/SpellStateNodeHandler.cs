namespace ET
{
    public class SpellStateNodeHandler : ANodeHandler<SpellStateNode>
    {
        public override async ETTask<bool> Run(SpellStateNode node, BTEnv env)
        {
            var spell = env.Get<Spell>(node.Spell);
            // if(spell.GetComponent<SpellStateComponent>()!=null)
            //     spell.RemoveComponent<SpellStateComponent>();
            // else
            //     spell.AddComponent<SpellStateComponent>();
            await ETTask.CompletedTask;
            return true;
        }
    }
}