namespace ET
{
    public class M2C_InitInventoryHandler : AMHandler<M2C_InitInventory>
    {
        protected override async ETVoid Run(Session session, M2C_InitInventory message)
        {
            var myUnit = session.GetMyUnit();
            var com = myUnit.GetComponent<InventoryComponent>();
            foreach (var v in message.Items)
            {
                com.Add(ItemFactory.CreateFromProto(com,v),v.Pos);
            }

            await ETTask.CompletedTask;
        }
    }
}