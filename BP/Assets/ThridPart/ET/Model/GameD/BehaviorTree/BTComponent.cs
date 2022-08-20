using System.Collections.Generic;

namespace ET
{
    public class BTComponentAwakeSystem: AwakeSystem<BTComponent, BehaviorTree, BehaviorTree>
    {
        public override void Awake(BTComponent self, BehaviorTree a, BehaviorTree b)
        {
            self.viewTree = a;
            self.logicTree = b;
        }
    }

    public class BTComponent: Entity
    {
        public BehaviorTree viewTree;
        public BehaviorTree logicTree;
    }
}