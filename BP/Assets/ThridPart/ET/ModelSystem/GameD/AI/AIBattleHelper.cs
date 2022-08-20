using UnityEngine;

namespace ET
{
    public static class AIBattleHelper
    {
        public static async ETTask KillMaxHatred(Unit unit,ETCancellationToken token)
        {
            var com = unit.GetComponent<AIHatredComponent>();
            if (com == null)
                return;
            var maxHatred = com.GetMaxHatred();
            if (maxHatred == null)
                return;
            var targetUnit = unit.Domain.GetComponent<UnitComponent>().Get(maxHatred.Id);

            bool action = true;
            token.Add(() => action = false);
            var dis = GetRadiusDis(unit, targetUnit);
            var theta = RandomHelper.RandomNumber(0, 36) * 10;
            // 靠近
            for (int i = 0; i < 20; i++)
            {
                if (!action)
                    return;
                var targetPos = targetUnit.Position + new Vector3(Mathf.Cos(theta), 0, Mathf.Sin(theta)) * dis;
                var ret = await unit.MoveToAsync(targetPos, 0, token);
                if (ret != 0)
                    continue;
                //todo: 加入战斗行为
                var spellId = ChooseSpells(unit);
                var spell = SpellFactory.SimpleCreate(unit, spellId);
                await SpellHelper.CastSpellAndWait(spell,targetUnit.Position);
            }
        }

        public static float GetRadiusDis(Unit unit, Unit target)
        {
            return (unit.Config.Radius + target.Config.Radius) / 1000.0f;
        }

        public static void SetHatred(Unit unit,long targetId, int value)
        {
            var com = unit.GetOrAdd<AIHatredComponent>();
            com.SetHatred(targetId,value);
        }

        static int ChooseSpells(Unit unit)
        {
            var initSpells = unit.Config.InitSpells;
            if (initSpells == null || initSpells.Length == 0)
                return 0;
            return initSpells.RandomArray(); //todo: 后续要根据敌人和自身的情况选择技能
        }
    }
}