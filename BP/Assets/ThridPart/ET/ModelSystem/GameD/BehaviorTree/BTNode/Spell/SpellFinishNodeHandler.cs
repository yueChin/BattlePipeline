namespace ET
{
    public class SpellFinishNodeHandler : ANodeHandler<SpellFinishNode>
    {
        public override async ETTask<bool> Run(SpellFinishNode node, BTEnv env)
        {
            var spell = env.Get<Spell>(node.Spell);
            spell.Finish();
            await ETTask.CompletedTask;
            return true;
        }
    }
}