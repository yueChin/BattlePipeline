namespace ET
{
    public class M2C_InitMapHandler : AMHandler<M2C_InitMap>
    {
        protected override async ETVoid Run(Session session, M2C_InitMap message)
        {
            var currScene = session.CurrScene();
            foreach (UnitInfo unitInfo in message.Units)
            {
                await UnitFactory.CreateFromProto(currScene, unitInfo);
            }

            await ETTask.CompletedTask;
            await MapHelper.InitMap(currScene);
        }
    }
}