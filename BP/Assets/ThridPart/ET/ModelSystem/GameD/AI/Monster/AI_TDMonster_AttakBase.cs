namespace ET
{
    public class AI_TDMonster_AttakBase : AAIHandler
    {
        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
        {
            return 0;
        }

        public override async ETVoid Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            var baseUnit = aiComponent.Domain.GetComponent<UnitComponent>().GetOneByConfigId((int) UnitIdConst.Base);
            if (baseUnit == null)
            {
                return;
            }

            var self = aiComponent.GetParent<Unit>();
            // var dis = AIBattleHelper.GetRadiusDis(self, baseUnit);
            //
            // var ret = await self.MoveToAsync(baseUnit.Position, dis, cancellationToken);
            // if (ret != 0)
            //     return;


            //todo: 加入战斗内容
            AIBattleHelper.SetHatred(self, baseUnit.Id, 1000);
            await AIBattleHelper.KillMaxHatred(self, cancellationToken);

        }
    }
}