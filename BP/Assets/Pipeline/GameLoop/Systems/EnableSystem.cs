﻿using System;
using Unity.VisualScripting;

namespace Pipeline.Systems
{
    public class EnableSystem<T> : System
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