using ET.EventIdType;
using UnityEngine;

namespace ET
{
    public class OnInventoryAdd_RefreshUI : AEvent<EventIdType.InventoryAdd>
    {
        protected override async ETTask Run(InventoryAdd a)
        {
            var ui = a.scene.GetComponent<UIComponent>().Get(UIType.UIInventory);
            if (ui == null)
                return;
            ui.GetComponent<UIInventoryViewComponent>().Adaptor.Inventory_Add(a.Pos,a.Item);
            await ETTask.CompletedTask;
        }
    }
}