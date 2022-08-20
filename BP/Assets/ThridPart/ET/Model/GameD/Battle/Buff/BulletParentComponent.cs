using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class BulletParentComponent : Entity
    {
        public Unit unit; // 谁发射的子弹
        public Unit target; // 一般是当前被子弹碰到的人
    }
}
