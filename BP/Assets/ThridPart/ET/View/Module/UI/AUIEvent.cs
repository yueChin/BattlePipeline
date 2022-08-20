namespace ET
{
    public abstract class AUIEvent
    {
        public abstract ETTask OnCreate(UI ui);
        public abstract void OnRemove(UI ui);
    }
}