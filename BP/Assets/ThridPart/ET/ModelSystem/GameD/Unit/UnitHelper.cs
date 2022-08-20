using ET.EventIdType;

namespace ET
{
    public static class UnitHelper
    {
        public static async ETTask Revive(Unit unit)
        {
            unit.GetComponent<NumericComponent>().Set(NumericType.Die,0);
            await Game.EventSystem.Run(new OnUnitRevive() { target = unit });
        }
    }
}