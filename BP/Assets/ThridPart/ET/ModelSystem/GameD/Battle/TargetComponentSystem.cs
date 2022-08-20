using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [ObjectSystem]
    public class TargetComponentAwakeSystem : AwakeSystem<TargetsComponent,Unit>
    {
        public override void Awake(TargetsComponent self, Unit target)
        {

        }
    }

    [ObjectSystem]
    public class TargetComponentDestorySystem : DestroySystem<TargetsComponent>
    {
        public override void Destroy(TargetsComponent self)
        {
            self.TargetsInstanceId.Clear();
        }
    }

    public static class TargetComponentEx
    {

    }
}
