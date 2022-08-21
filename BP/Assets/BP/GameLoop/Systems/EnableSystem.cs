using System;
using Unity.VisualScripting;

namespace Pipeline.Systems
{
    public class EnableSystem<T> : BPSystem
    {
        public override void Tick()
        {
            
        }

        public override Type Type()
        {
            return typeof(T);
        }
    }
}