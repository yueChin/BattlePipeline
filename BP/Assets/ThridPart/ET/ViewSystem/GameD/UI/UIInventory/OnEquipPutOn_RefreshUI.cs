using ET.EventIdType;
using UnityEngine;

namespace ET
{
    public class OnEquipPutOn_RefreshUI : AEvent<EventIdType.PutOnEquip>
    {
        protected override async ETTask Run(PutOnEquip a)
        {
            var ui = a.unit.Domain.GetComponent<UIComponent>().Get(UIType.UIInventory);
            if (ui == null)
                return;
            ui.GetComponent<UIInventoryViewComponent>().Adaptor.Equip_Add(a.EquipPoint,a.Item);
            await ETTask.CompletedTask;
        }
    }
}