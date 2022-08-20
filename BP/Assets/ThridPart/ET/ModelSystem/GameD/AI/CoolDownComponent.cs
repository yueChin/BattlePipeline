namespace ET
{
    public class CoolDownDestroySystem : DestroySystem<CoolDown>
    {
        public override void Destroy(CoolDown self)
        {
            TimerComponent.Instance.Remove(ref self.disposeTimer);
        }
    }
    public class CoolDownAwakeSystem : AwakeSystem<CoolDown,long>
    {
        public override void Awake(CoolDown self,long disposeTime)
        {
            self.disposeTimer = TimerComponent.Instance.NewOnceTimer(TimeHelper.ServerNow() + disposeTime,
                self.Dispose);
        }
    }
    
    public static class CoolDownComponentEx
    {
        public static void AddCoolDown(this Entity self,CoolDownType type,long duration)
        {
            self.RemoveCoolDown(type);
            EntityFactory.CreateWithParentAndId<CoolDown, long>(self, (long) type, duration);
        }

        public static void RemoveCoolDown(this Entity self, CoolDownType type)
        {
            var cool = self.GetChild<CoolDown>((long) type);
            cool?.Dispose();
        }

        public static bool HasCoolDown(this Entity self, CoolDownType type)
        {
            var cool = self.GetChild<CoolDown>((long) type);
            if (cool != null)
                return true;
            return false;
        }
    }
}