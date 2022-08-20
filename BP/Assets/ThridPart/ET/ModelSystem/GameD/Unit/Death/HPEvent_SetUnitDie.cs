using System;

namespace ET
{
    [NumericWatcher(NumericType.HP)]
    public class HPEvent_SetUnitDie : INumericWatcher
    {
        public void Run(Unit unit, long oldValue, long newValue)
        {
            Log.Debug("当前血量 " + newValue);
            if (newValue > 0 || oldValue<=0)
                return;
            unit.GetComponent<NumericComponent>().Set(NumericType.Die, 1);
        }
    }
}