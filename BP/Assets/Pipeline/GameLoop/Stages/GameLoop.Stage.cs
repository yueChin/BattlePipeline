using System;
using System.Collections.Generic;

namespace Pipeline
{
    public partial class GameLoop
    {
        public class Stage
        {
            private bool m_IsInit = false;
            private readonly Dictionary<Type,List<Systems.System>> m_UpdateSystemDict = new Dictionary<Type,List<Systems.System>>();
            private readonly List<Systems.System> m_RemoveSystemList = new List<Systems.System>();
            public int Index;
            
            public virtual void Update()
            {
                if (!m_IsInit)
                {
                    for (int i = 0; i < m_UpdateSystemDict.Count; i++)
                    {
                    }
                }
                
                
            }
            
            public void RemoveChildSystem(Systems.System system)
            {
                m_RemoveSystemList.Remove(system);
            }
        }
    }
}