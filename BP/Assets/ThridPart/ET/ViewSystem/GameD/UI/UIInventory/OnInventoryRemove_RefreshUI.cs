using ET.EventIdType;
using UnityEngine;

namespace ET
{
    public class OnInventoryARemove_RefreshUI : AEvent<EventIdType.InventoryRemove>
    {
        protected override async ETTask Run(InventoryRemove a)
        {
            var ui = a.scene.GetComponent<UIComponent>().Get(UIType.UIInventory);
            if (ui == null)
                return;
            ui.GetComponent<UIInventoryViewComponent>().Adaptor.Inventory_Remove(a.Pos);
            await ETTask.CompletedTask;
        }
    }
}