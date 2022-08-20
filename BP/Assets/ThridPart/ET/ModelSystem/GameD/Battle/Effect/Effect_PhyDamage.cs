namespace ET
{
    [Effect(EffectType.PhyDamage)]
    public class Effect_PhyDamage : IEffectHandler
    {
        public void Handle(EffectTriggerType effectTriggerType, Effect effect)
        {
            var spell = effect.EffectSpell;
            var target = effect.Target;
            var param = effect.EffectConfig.EffectParams[0];
            var caster = spell.Caster;

            var damage = caster.GetComponent<NumericComponent>().GetAsLong(NumericType.PATK) * param / 1000;
            DamageHelper.CreateDamage(caster, target, DamageType.Physics, damage);

        }
    }
}