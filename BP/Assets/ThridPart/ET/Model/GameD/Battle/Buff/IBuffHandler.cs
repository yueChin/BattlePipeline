using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public interface IBuffAddHandler
    {
        void Add(Buff buff);
    }
    public interface IBuffUpdateHandler
    {
        void Update(Buff buff);
    }
    public interface IBuffRemoveHandler
    {
        void Remove(Buff buff);
    }
    public interface IBuffTickHandler
    {
        void Tick(Buff buff);
    }
}
