using UnityEditorInternal;

namespace ET
{
    public class EPLevelControlAwakeSystem : AwakeSystem<EPLevelControl,int>
    {
        public override void Awake(EPLevelControl self, int a)
        {
            self.ConfigId = a;
            self.Car = self.Domain.GetComponent<UnitComponent>().GetOneByConfigId((int) UnitIdConst.Car);
            self.Start().Coroutine();
        }
    }

    public static class EPLevelControlEx
    {
        public static async ETVoid Start(this EPLevelControl self)
        {
            for (self.Index = 0; self.Index < self.Path.Count; self.Index++)
            {
                var target = self.Path[self.Index];
                var ret = await self.Car.MoveToAsync(target);
                if (ret != 0)
                {
                    return;
                }

                if (self.IsDisposed)
                    return;
                
            }
        }
    }
}