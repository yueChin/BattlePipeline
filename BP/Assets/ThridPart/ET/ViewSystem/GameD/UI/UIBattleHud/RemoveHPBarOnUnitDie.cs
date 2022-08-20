using ET.EventIdType;

namespace ET
{
    
    public class OnUnitDie_RemoveHPBar : AEvent<OnUnitDie>
    {
        protected override async ETTask Run(OnUnitDie data)
        {
            var ui = data.target.Domain.GetComponent<UIComponent>().Get(UIType.UIBattleHud);
            if (ui == null)
                return;
            await ETTask.CompletedTask;
        }
    }
}