namespace ET
{
    public static class NumericHelper
    {
        public static bool GetAlive(this Unit unit)
        {
            return unit.GetComponent<NumericComponent>().GetAsInt(NumericType.Die) == 0;
        }
    }
}