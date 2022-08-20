using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class BuffAttribute : BaseAttribute
    {
        public BuffIDConst buffType;
        public BuffAttribute(BuffIDConst buffType)
        {
            this.buffType = buffType;
        }
    }
}
