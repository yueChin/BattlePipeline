using ET.EventIdType;

namespace ET
{
    public class OnUnitDieEventHandler : AEvent<OnUnitDie>
    {
        protected override async ETTask Run(OnUnitDie data)
        {
            if(data.target.Config.UnitType == (int) UnitType.Player)
                return;
            
            //todo: 普通怪物直接死，重要的怪物通知服务器 、联机游戏里都通知服务器

            data.target.AddComponent<UnitAutoDestoryComponent, int>(2000); // 尸体留两秒后移除

            await ETTask.CompletedTask;
        }
    }
}