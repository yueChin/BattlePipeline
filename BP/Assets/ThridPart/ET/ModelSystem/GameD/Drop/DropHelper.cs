namespace ET
{
    public static class DropHelper
    {
        public static async ETTask PickUp(Unit myUnit, long dropId)
        {
            var req = new C2M_PickUpDrop()
            {
                UnitId = dropId
            };
            var resp = await myUnit.CurrSession().Call(req);
        }
    }
}