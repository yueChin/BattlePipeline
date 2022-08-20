using UnityEngine;

namespace ET
{
    public class AI_TDMonster_KillEnemy : AAIHandler
    {
        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
        {
            var unit = aiComponent.GetParent<Unit>();
            var targetCamp = unit.GetEnemyCamp();
            if (!unit.Domain.GetComponent<UnitComponent>().CampUnits.ContainsKey(targetCamp))
            {
                return -1;
            }

            if (aiComponent.HasCoolDown(CoolDownType.TDMonster_FindEnemy))
                return -1;

            aiComponent.AddCoolDown(CoolDownType.TDMonster_FindEnemy,2000);
            
            foreach (var v in unit.Domain.GetComponent<UnitComponent>().CampUnits[targetCamp])
            {
                var targetUnit = unit.Domain.GetComponent<UnitComponent>().Get(v);
                if(targetUnit.IsDisposed)
                    continue;
                if (BattleHelper.IsFriend(unit, targetUnit))
                {
                    continue;
                }

                if (Vector3.SqrMagnitude(unit.Position - targetUnit.Position) > 4) //todo: 后续读怪物配置
                {
                    continue;
                }
                
                unit.GetComponent<AIHatredComponent>().SetHatred(targetUnit.Id,1);//todo: 定义一个初始仇恨

                return 0;
            }

            return - 1;
        }

        public override async ETVoid Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            await AIBattleHelper.KillMaxHatred(aiComponent.GetOrAdd<Unit>(), cancellationToken);
        }
    }
}