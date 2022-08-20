namespace ET
{
    public static class NumericComponentSystem
    {
        public static void InitByLevel(this NumericComponent self, int level)
        {
            self.SetWithoutEvent(NumericType.Level,level);
            var baseConfig = LevelNumericConfigCategory.Instance.Get(level);
            var unitConfig = self.GetParent<Unit>().Config;
            var half = baseConfig.NumericKeys.Length / 2;
            for (int i = 0; i < half; i++)
            {
                var key = baseConfig.NumericKeys[i];
                long value = baseConfig.NumericKeys[i + half];
                switch ((NumericType)key)
                {
                    case NumericType.MaxHPBase:
                        value = value * (1000 + unitConfig.HPRefix) / 1000;
                        break;
                    case NumericType.PATKBase:
                        case NumericType.MATKBase:
                        value = value * (1000 + unitConfig.ATKRefix) / 1000;
                        break;
                    case NumericType.PDEFBase:
                        value = value * (1000 + unitConfig.PDEFRefix) / 1000;
                        break;
                    case NumericType.MDEFBase:
                        value = value * (1000 + unitConfig.MDEFRefix) / 1000;
                        break;
                    case NumericType.MoveSpeedBase:
                        value = value * (1000 + unitConfig.MoveSpeedRefix) / 1000;
                        break;
                    case NumericType.HPRecoverSpeedBase:
                        value = value * (1000 + unitConfig.HPRecoverRefix) / 1000;
                        break;
                        
                }
                self.SetWithoutEvent((NumericType) key,value);
            }
            
            self.SetWithoutEvent(NumericType.HP,self.GetAsLong(NumericType.MaxHP));
        }
    }
}