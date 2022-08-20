using JetBrains.Annotations;

namespace ET
{
    public class SpellStateComponentAwakeSystem : AwakeSystem<SpellStateComponent,int>
    {
        public override void Awake(SpellStateComponent self,int disposeTime)
        {
            var spell = self.GetParent<Spell>();
            var spellCom = spell.Caster.GetComponent<SpellComponent>();
            spellCom.SpellState++;

            self.timer = TimerComponent.Instance.NewOnceTimer(TimeHelper.ServerNow() + disposeTime, self.Dispose);
        }
    }
    
    public class SpellStateComponentDestroySystem : DestroySystem<SpellStateComponent>
    {
        public override void Destroy(SpellStateComponent self)
        {
            var spell = self.GetParent<Spell>();
            var spellCom =spell.Caster.GetComponent<SpellComponent>();
            spellCom.SpellState--;
            TimerComponent.Instance.Remove(ref self.timer);
        }
    }
}