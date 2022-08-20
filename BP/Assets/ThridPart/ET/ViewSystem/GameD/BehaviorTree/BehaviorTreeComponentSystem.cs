using System.Collections.Generic;

namespace ET
{
    [ObjectSystem]
    public class BehaviorTreeComponentAwakeSystem : AwakeSystem<BehaviorTreeComponent>
    {
        public override void Awake(BehaviorTreeComponent self)
        {
            BehaviorTreeComponent.Instance = self;
            self.LoadHandlers();
        }

    }

    [ObjectSystem]
    public class BehaviorTreeComponentLoadSystem : LoadSystem<BehaviorTreeComponent>
    {
        public override void Load(BehaviorTreeComponent self)
        {
            self.LoadHandlers();
        }

    }

    public static class BehaviorTreeComponentEx
    {
        public static async ETTask LoadAllBT(this BehaviorTreeComponent self)
        {
            self.BehaviorTrees.Clear();
            var dict = new Dictionary<string, string>();
            await self.loader.GetAllBehaviorTree(dict);
            foreach (var v in dict)
            {
                Log.Debug("添加行为树 "+v.Key);
                self.Add(v.Key,MongoHelper.FromJson<BehaviorTree>(v.Value));
            }
        }
    }
}