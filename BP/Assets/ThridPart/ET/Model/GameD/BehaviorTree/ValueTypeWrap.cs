using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ValueTypeWrap<T> : Entity, IValue<T>
    {
        public T Value { get; set; }
    }
}
