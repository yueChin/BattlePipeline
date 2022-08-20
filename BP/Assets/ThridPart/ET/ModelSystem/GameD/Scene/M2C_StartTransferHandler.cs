namespace ET
{
    public class M2C_StartTransferHandler : AMHandler<M2C_StartTransfer>
    {
        protected override async ETVoid Run(Session session, M2C_StartTransfer message)
        {
            await session.ZoneScene().GetComponent<SceneComponent>().ChangeScene(message.MapConfigId);
            var currScene = session.CurrScene();
            var unitInfo = message.MyUnit;
            await UnitFactory.CreateMyUnitFromProto(currScene, unitInfo);
            session.Send(new C2M_TransferEnd());
        }
    }
}