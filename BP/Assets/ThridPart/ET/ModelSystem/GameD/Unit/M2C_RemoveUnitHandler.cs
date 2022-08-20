namespace ET
{
    public class M2C_RemoveUnitHandler : AMHandler<M2C_RemoveUnit>
    {
        protected override async ETVoid Run(Session session, M2C_RemoveUnit message)
        {
            var currScene = session.CurrScene();
            UnitComponent unitComponent = currScene.GetComponent<UnitComponent>();
            foreach (var v in message.UnitIds)
            {
                unitComponent.Remove(v);
            }

            await ETTask.CompletedTask;
        }
    }
}