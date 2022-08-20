namespace ET
{
    public class M2C_InventoryUpdateHandler : AMHandler<M2C_InventoryUpdate>
    {
        protected override async ETVoid Run(Session session, M2C_InventoryUpdate message)
        {
            var myUnit = session.GetMyUnit();
            var com = myUnit.GetComponent<InventoryComponent>();
            foreach (var v in message.DeleteSet)
            {
                com.Remove(v,true);
            }

            foreach (var v in message.NewSet)
            {
                com.Add(ItemFactory.CreateFromProto(com,v),v.Pos);
            }

            await ETTask.CompletedTask;
        }
    }
}