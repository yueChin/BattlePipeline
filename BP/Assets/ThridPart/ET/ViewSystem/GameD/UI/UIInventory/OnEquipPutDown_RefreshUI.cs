using ET.EventIdType;
using UnityEngine;

namespace ET
{
    public class OnEquipPutDown_RefreshUI : AEvent<EventIdType.PutDownEquip>
    {
        protected override async ETTask Run(PutDownEquip a)
        {
            var ui = a.unit.Domain.GetComponent<UIComponent>().Get(UIType.UIInventory);
            if (ui == null)
                return;
            ui.GetComponent<UIInventoryViewComponent>().Adaptor.Equip_Remove(a.EquipPoint);
            await ETTask.CompletedTask;
        }
    }
}