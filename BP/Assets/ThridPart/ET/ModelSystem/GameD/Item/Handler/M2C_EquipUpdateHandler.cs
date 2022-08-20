namespace ET
{
    public class M2C_EquipUpdateHandler : AMHandler<M2C_EquipUpdate>
    {
        protected override async ETVoid Run(Session session, M2C_EquipUpdate message)
        {
            var myUnit = session.GetMyUnit();
            var com = myUnit.GetComponent<EquipComponent>();
            if (message.Item == null)
            {
                com.AllEquips.TryGetValue(message.EquipPoint, out var item);
                await Game.EventSystem.Run(new EventIdType.PutDownEquip() { unit = myUnit, EquipPoint = message.EquipPoint,Item = item});
                com.AllEquips.Remove(message.EquipPoint);
                item.Dispose();
            }
            else
            {
                var item = ItemFactory.CreateFromProto(com, message.Item);
                com.AllEquips[message.EquipPoint] = item;

                await Game.EventSystem.Run(new EventIdType.PutOnEquip() { unit = myUnit, EquipPoint = message.EquipPoint, Item = item });
            }

            await ETTask.CompletedTask;
        }
    }
}