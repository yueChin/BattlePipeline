namespace ET
{
    public class UnitAutoDestoryComponentAwakeSystem : AwakeSystem<UnitAutoDestoryComponent,int>
    {
        public override void Awake(UnitAutoDestoryComponent self, int a)
        {
            self.timer = TimerComponent.Instance.NewOnceTimer(TimeHelper.ServerNow() + a, ()=>Destory(self));
        }

        void Destory(UnitAutoDestoryComponent self)
        {
            self.Domain.GetComponent<UnitComponent>().Remove(self.GetParent<Unit>().Id);
        }
    }
    
    public class UnitAutoDestoryComponentDestroySystem : DestroySystem<UnitAutoDestoryComponent>
    {
        public override void Destroy(UnitAutoDestoryComponent self)
        {
            TimerComponent.Instance.Remove(ref self.timer);
        }
    }
}