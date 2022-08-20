using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ET
{
    public static class SpellHelper
    {
        public static int CheckCond(Unit unit, int spellConfigId)
        {
            var spellCom = unit.GetComponent<SpellComponent>();
            if (spellCom.CoolDownTimers.ContainsKey(spellConfigId))
            {
                //  Log.Debug("在冷却中");
                return ErrorCode.ERR_CastSpell_InCD;
            }
            
            if (spellCom.CurrUsing.ContainsKey(spellConfigId))
            {
                return (int) ErrorCode.ERR_CastSpell_IsUsing; 
            }

            var spellConfig = SpellConfigCategory.Instance.Get(spellConfigId);

            if (!unit.GetAlive())
            {
                return (int) ErrorCode.ERR_CastSpell_IsDead;
            }
            

            if (!spellConfig.CanUseInSpellState)
            {
                if (spellCom.SpellState > 0)
                {
                    return (int) ErrorCode.ERR_CastSpell_InSpellState; // 当前状态无法使用该技能
                }
            }

            return ErrorCode.ERR_Success;
        }

        public static int CheckTarget(Unit unit, Spell spell)
        {
            return 0;

        }


        public static async ETTask CastSpellAndWait(Spell spell,Vector3 hitPoint)
        {
            var ret = Cast(spell,hitPoint);
            if (ret != 0)
                return;
            await spell.task;
        }

        public static int Cast(Spell spell,Vector3 hitPoint)
        {
            var spellCom = spell.Caster.GetComponent<SpellComponent>();

            //  判断是否可以释放
            int checkResult = CheckCond(spell.Caster, spell.SpellConfigId);
            if (checkResult != 0)
            {
                spell.Dispose();
                return checkResult;
            }

            checkResult = CheckTarget(spell.Caster, spell);
            if (checkResult != 0)
            {
                spell.Dispose();
                return checkResult;
            }

            if (spell.SpellConfig.SpellStateDuration > 0)
            {
                spell.AddComponent<SpellStateComponent, int>(spell.SpellConfig.SpellStateDuration);
            }
            
            // 转向目标
            var tarDir = hitPoint - spell.Caster.Position;
            spell.Caster.Forward = tarDir.normalized;

           // Log.Debug("准备执行技能 "+spell.SpellConfigId);
            spellCom.CurrUsing[spell.SpellConfigId] = spell;
            spell.InitBT();

            Game.EventSystem.Run(new EventIdType.CastSpell() { spell = spell });

            BTHelper.Execute(BTSwitch.SpellStart, spell);
            return ErrorCode.ERR_Success;
        }

        public static void CastChild(Spell child)
        {
            var parent = child.GetParent<Spell>();
            if (parent == null)
            {
                Log.Error("非子技能作为子技能Cast");
                child.Dispose();
                return;
            }
            //todo: 可能还有其他要加的组件
            if (parent.GetComponent<TargetPosComponent>() != null)
                child.GetOrAdd<TargetPosComponent>().targetPos = parent.GetComponent<TargetPosComponent>().targetPos;
            if (parent.GetComponent<LockTargetComponent>() != null)
                child.GetOrAdd<LockTargetComponent>().target = parent.GetComponent<LockTargetComponent>().target;
            if (parent.GetComponent<TargetsComponent>() != null)
                child.GetOrAdd<TargetsComponent>().TargetsInstanceId.AddRange(parent.GetComponent<TargetsComponent>().TargetsInstanceId);


            int checkResult = CheckTarget(child.Caster, child);
            if (checkResult != 0)
            {
                child.Finish();
                return;
            }
            
            if (child.SpellConfig.SpellStateDuration > 0)
            {
                child.AddComponent<SpellStateComponent, int>(child.SpellConfig.SpellStateDuration);
            }

            
            child.InitBT();
            BTHelper.Execute(BTSwitch.SpellStart, child);
            Game.EventSystem.Run(new EventIdType.CastSpell() { spell = child });
        }

        public static async ETVoid Interrupt(Spell spell)
        {
            //todo: 判断是否可以打断
            if (spell == null || spell.IsDisposed) return;
            var parent = spell.GetParent<Spell>();
            if (parent != null)
            {
                Interrupt(parent).Coroutine();
                return;
            }

            await BTHelper.ExecuteAsync(BTSwitch.SpellInterrupt, spell);

            await Game.EventSystem.Run(new EventIdType.InterruptSpell() { spell = spell });
            Clear(spell);
        }

        public static void InterruptCurrUsing(Unit unit)
        {
            //var spellCom = unit.GetComponent<SpellComponent>();
        }

        public static void SetCoolDownTimer(this SpellComponent self,int spellConfigId, long coolDownTime)
        {
            if (self.CoolDownTimers.TryGetValue(spellConfigId, out var timer))
            {
                timer.Dispose();
                self.CoolDownTimers.Remove(spellConfigId);
            }
            var coolDown = EntityFactory.CreateWithParent<SpellCoolDownTimer>(self);
            self.CoolDownTimers[spellConfigId] = coolDown;
            coolDown.startTime = TimeHelper.ServerNow();

            // 考虑冷却缩减
            coolDown.endTime = coolDown.startTime + coolDownTime;
            coolDown.coolDownTimer = TimerComponent.Instance.NewOnceTimer(coolDown.endTime, () =>
             {
                 coolDown.Dispose();
                // Log.Debug("移除冷却");
                 self.CoolDownTimers.Remove(spellConfigId);
             });
           // Log.Debug("添加冷却");

        }

        public static void Finish(this Spell spell)
        {
            if (spell == null || spell.IsDisposed) return;
            var parent = spell.GetParent<Spell>();
            if (parent != null)
            {
                parent.Finish();
                return;
            }

            BTHelper.Execute(BTSwitch.SpellFinish, spell);
            Clear(spell);

        }

        public static void Clear(Spell spell)
        {
            var spellCom = spell.Caster.GetComponent<SpellComponent>();
            if (spell.SpellConfig.ColdDown > 0)
            {
                spellCom.SetCoolDownTimer(spell.SpellConfigId, spell.SpellConfig.ColdDown);
            }
            spell.Dispose();
        }
    }
}
