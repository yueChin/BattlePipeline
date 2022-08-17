using System;
using Unity.VisualScripting;

namespace Pipeline.Systems
{
    public class DisableSystem<T> : System
    {
        public override void Tick()
        {
            
        }

        public Type Type()
        {
            return typeof(T);
        }
    }
}