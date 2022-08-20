using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    // 伤害类别
    [Flags]
    public enum DamageType
    {
        Physics = 1 << 0, // 物理伤害
        Magic = 1 << 1, // 魔法伤害   
        Real = 1 << 2, // 真实伤害
        Continue = 1 << 3, // 持续伤害
        Bleed = 1 << 4, // 流血伤害
        Ignite = 1 << 5, // 点燃伤害
        Poision = 1 << 6, // 中毒伤害
        System = 1 << 31, // 不可被闪避，格挡，免疫等忽略的伤害，一般用于机制杀
    }
    [Flags]
    public enum DamageResultType
    {
        Normal = 1 << 0,
        Dodge = 1 << 1, // 闪避
        Critical = 1 << 2, // 暴击伤害
        SuperCritical = 1 << 3, // 会心伤害
        Block = 1 << 4, // 格挡
        Death = 1 << 5, // 致死
        Immune = 1 << 6, // 免疫
    }
}
