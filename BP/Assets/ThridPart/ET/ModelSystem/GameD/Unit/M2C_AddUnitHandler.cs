namespace ET
{
    public class M2C_AddUnitHandler : AMHandler<M2C_AddUnit>
    {
        protected override async ETVoid Run(Session session, M2C_AddUnit message)
        {
            var currScene = session.CurrScene();
            UnitComponent unitComponent = currScene.GetComponent<UnitComponent>();
            foreach (UnitInfo unitInfo in message.Units)
            {
                if (unitComponent.Get(unitInfo.UnitId) != null)
                {
                    continue;
                }
                await UnitFactory.CreateFromProto(currScene, unitInfo);
            }
        }
    }
}