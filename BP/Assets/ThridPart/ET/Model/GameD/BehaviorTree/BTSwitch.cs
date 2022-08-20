namespace ET
{
    // 不能改已定义的数值，否则行为树可能会异常
    public enum BTSwitch
    {
        
        BTUpdate = 100, // 通用行为树Update
        
        // Unit 1001~1999
        UnitAdd = 1001,
        UnitRemove = 1002,
        UnitDie = 1004,
        UnitHit = 1005,
        UnitRevive = 1006,
        UnitBeginMove = 1007,
        UnitStopMove = 1008,
        UnitCollide = 1009,
        UnitStartJump = 1010 ,
        UnitStopJump = 1011,

        //Spell 2001~2999
        SpellStart = 2001,
        SpellHit = 2002,
        SpellFinish = 2003,
        SpellInterrupt = 2004,
        SpellRelease = 2006,
        SpellSndClick = 2007, // 二次触发，一般用于一个技能第二次释放时的效果
        SpellChargeRelease = 2008, // 充能完毕

        // Item 4001~4999
        ItemLeftDown = 4001,
        ItemLeftPress = 4002,
        ItemLeftUp = 4003,
        ItemRightDown = 4004,
        ItemRightPress = 4005,
        ItemRightUp = 4006,
        //特殊交互键1
        ItemKeyDown_E = 4008,
        ItemKeyPress_E = 4009,
        ItemKeyUp_E = 4010,
           //特殊交互键2
        ItemKeyDown_R = 4011,
        ItemKeyPress_R = 4012,
        ItemKeyUp_R = 4013,

        ItemEquip = 4100,
        ItemUnEquip = 4101,
    }
}