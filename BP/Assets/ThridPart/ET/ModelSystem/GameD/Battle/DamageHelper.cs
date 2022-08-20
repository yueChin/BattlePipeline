using ET.EventIdType;

namespace ET
{
    public static class DamageHelper
    {
        public static void CreateDamage(Unit caster, Unit target, DamageType damageType, long initDamage)
        {
              var casterNum = caster.GetComponent<NumericComponent>();
            var targetNum = target.GetComponent<NumericComponent>();
            long damage = initDamage;
            var maxRate = ConstValue.MaxDodgeRate;

            var resultType = DamageResultType.Normal;

            if (!damageType.HasFlag(DamageType.System))
            {
                {
                    // 先判断是否闪避
                    {
                        var dodge = targetNum.GetAsLong(NumericType.DodgeRate);
                        if (dodge > maxRate)
                            dodge = maxRate;
                        if (RandomHelper.RandomNumber(1, 1000) <= dodge)
                        {
                            // 闪避成功
                            Game.EventSystem.Run( new DamageResult()
                            {
                                Target = target,
                                damage = 0,
                                Type = resultType & DamageResultType.Dodge
                            }).Coroutine();
                            return;
                        }
                    }
                }


                // 判断暴击
                {
                    var crit = casterNum.GetAsLong(NumericType.CritRate) - targetNum.GetAsLong(NumericType.ResistCritRate);
                    if (RandomHelper.RandomNumber(1, 1000) <= crit)
                    {
                        resultType &= DamageResultType.Critical;
                        var effect = casterNum.GetAsLong(NumericType.CriteDamageRate) + ConstValue.CritDamageInitRate;
                        damage = (long)(damage * (1 + effect / 1000f));
                    }
                }

                // 判断格挡
                {
                    long blockRate = 0;
                    if (damageType.HasFlag(DamageType.Physics))
                    {
                        blockRate = targetNum.GetAsLong(NumericType.PBlockRate);
                    }
                    else
                    {
                        blockRate = targetNum.GetAsLong(NumericType.MBlockRate);
                    }
                    if (blockRate > maxRate)
                        blockRate = maxRate;
                    if (RandomHelper.RandomNumber(1, 1000) <= blockRate)
                    {
                        resultType &= DamageResultType.Block;
                        // 格挡成功
                        var blockEffect = ConstValue.BlockEffectInitRate + targetNum.GetAsLong(NumericType.BlockEffect);
                        if (blockEffect > maxRate)
                            blockEffect = maxRate;
                        damage = damage * (1000 - blockEffect) / 1000;
                    }
                }


                // 先根据伤害类型判断经过对方护甲/抗性消减后的值

                if (damageType.HasFlag(DamageType.Physics))
                {
                    // 防御力/（防御力+ x * 攻击方角色等级） 暂定x取50
                    var pdef = targetNum.GetAsLong(NumericType.PDEF);
                    var casterLevel = casterNum.GetAsLong(NumericType.Level);
                    var coeff = 50;
                    var reducePct = pdef / (float)(pdef + coeff * casterLevel);
                    damage = (long)(damage * (1 - reducePct));
                }
                else
                {
                    // 防御力/（防御力+ x * 攻击方角色等级） 暂定x取5
                    var mdef = targetNum.GetAsLong(NumericType.MDEF);
                    var casterLevel = casterNum.GetAsLong(NumericType.Level);
                    var coeff = 5;
                    var reducePct = mdef / (float)(mdef + coeff * casterLevel);
                    damage = (long)(damage * (1 - reducePct));
                }

                // 再判断物理伤害/魔法伤害 增加/减免的对抗
                if (damageType.HasFlag(DamageType.Physics))
                {
                    var casterAdd = casterNum.GetAsFloat(NumericType.PDamageUpRate);
                    var targetReduce = targetNum.GetAsFloat(NumericType.PDamageDownRate);
                    damage = (long)(damage * (1 + casterAdd) * (1 - targetReduce));
                }
                else
                {
                    var casterAdd = casterNum.GetAsFloat(NumericType.MDamageUpRate);
                    var targetReduce = targetNum.GetAsFloat(NumericType.MDamageDownRate);
                    damage = (long)(damage * (1 + casterAdd) * (1 - targetReduce));
                }

                // 再判断最终伤害增加/减免的对抗
                {
                    var casterAdd = casterNum.GetAsFloat(NumericType.FinalDamageUpRate);
                    var targetReduce = targetNum.GetAsFloat(NumericType.FinalDamageDownRate);
                    damage = (long)(damage * (1 + casterAdd) * (1 - targetReduce));
                }
            }

            var finalDamage = damage;

            // 先判断有无护盾
            var shield = targetNum.GetAsLong(NumericType.Shield);
            if (shield > 0)
            {
                damage -= shield;
                if (damage <= 0)
                {
                    targetNum.Change(NumericType.Shield, -damage);
                }
                else
                {
                    targetNum.Set(NumericType.Shield, 0);
                }

            }

            if (damage <= 0)
            {
                Game.EventSystem.Run( new DamageResult()
                {
                    Target = target,
                    damage = finalDamage,
                    Type = resultType
                }).Coroutine();
                return;
            }

            targetNum.Change(NumericType.HP, -damage);

            if (!target.GetAlive())
            {
                resultType &= DamageResultType.Death;
                Game.EventSystem.Run(new OnUnitDie()
                {
                     caster = caster,
                     target =  target
                }).Coroutine();
            }

            Game.EventSystem.Run( new DamageResult()
            {
                Target = target,
                damage = finalDamage,
                Type = resultType
            }).Coroutine();
        }
    }
}