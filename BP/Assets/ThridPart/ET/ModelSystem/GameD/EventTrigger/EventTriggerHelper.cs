namespace ET
{
    public static class EventTriggerHelper
    {
        // 客户端收到EventCondType的相关数据变化信息时,都执行一次CheckAll
        public static async ETTask CheckAll(Unit unit)
        {
            foreach (var v in EventTriggerConfigCategory.Instance.GetAll())
            {
                if (Check(unit, v.Key))
                {
                    //todo: 检测是否触发过
                    Trigger(unit, v.Key);
                }
            }

            await ETTask.CompletedTask;
        }

        public static void Trigger(Unit unit,int triggerId)
        {
            var trigger = EventTriggerConfigCategory.Instance.Get(triggerId);
            //todo:看效果是否要通知服务器还是客户端纯表现,  前者要告诉服务器,这个事件要触发了(服务器做一次Check验证)
            // 纯客户端的就客户端自己处理
        }


        public static bool Check(Unit unit, int triggerId)
        {
            var trigger = EventTriggerConfigCategory.Instance.Get(triggerId);
            if (trigger.Express.IsNullOrEmpty())
            {
                return false;
            }

            return LogicExpressionHelper.CalExpression(trigger.Express, v => Handle(unit, v));
        }

        static bool Handle(Unit unit,string cond)
        {
            int condId = int.Parse(cond);
            var condConfig = EventCondConfigCategory.Instance.Get(condId);
            switch ((EventCondType)condConfig.Type)
            {
                case EventCondType.Level:
                    return IntCompare(unit.GetComponent<NumericComponent>().GetAsInt(NumericType.Level), condConfig.Op, condConfig.Value);
            }

            return false;
        }

        static bool IntCompare(int ori, string op, int value)
        {
            switch (op)
            {
                case ">":
                    return ori > value;
                case ">=":
                    return ori >= value;
                case "<":
                    return ori < value;
                case "<=":
                    return ori <= value;
                case "=":
                case "==":
                    return ori == value;
                case "!=":
                    return ori != value;
            }

            return false;
        }
    }
}