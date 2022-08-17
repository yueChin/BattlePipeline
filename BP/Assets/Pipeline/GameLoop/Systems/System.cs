using System.Collections.Generic;
using Pipeline.Components;

namespace Pipeline.Systems
{
    
    public abstract class System
    {
        private bool m_IsEnable = false;
        private bool m_NeedDisable = false;

        public bool IsEnable => m_IsEnable;
        public bool NeedDisable => m_NeedDisable;

        private List<Component> m_ComponentList = new List<Component>();

        public virtual void BeforeTick()
        {
            
        }

        public virtual void AfterTick()
        {
            
        }
        
        public abstract void Tick();
    }
}