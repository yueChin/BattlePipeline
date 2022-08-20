namespace ET
{
    [ObjectSystem]
    public class SpellComponentAwakeSystem : AwakeSystem<SpellComponent>
    {
        public override void Awake(SpellComponent self)
        {
            var unit = self.GetParent<Unit>();
        }
    }
}