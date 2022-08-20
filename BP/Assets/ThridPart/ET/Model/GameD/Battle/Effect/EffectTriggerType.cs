using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public enum EffectTriggerType
    {
        SpellHit = -1, // 技能效果
        BuffAdd = 0, // Buff添加时
        BuffTimeOut = 1, // Buff超时移除
        BuffRemove = 2, // Buff移除时
        BuffTick = 3, // Buff更新时
        UnitDie = 4, // 角色死亡
        KillOther = 5, // 杀死其他角色时触发
        HitTarget = 6, // 子弹击中目标
    }
}
