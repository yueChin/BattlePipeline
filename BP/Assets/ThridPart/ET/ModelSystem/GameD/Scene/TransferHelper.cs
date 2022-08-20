namespace ET
{
    public static class TransferHelper
    {
        public static async ETTask RequestTransfer(Entity domain, int configId)
        {
            var req = new C2M_RequestTransfer { TransferConfigId = configId };
            var resp = await domain.CurrSession().Call(req);
        }
    }
}