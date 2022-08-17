using System.Collections.Generic;

namespace Pipeline
{
    public partial class GameLoop
    {
        public class StageGroup : Stage
        {
            private readonly List<Stage> m_ChildStageList = new List<Stage>();
            public override void Update()
            {
                if (m_ChildStageList.Count > 0)
                {
                    for (int i = 0; i < m_ChildStageList.Count; i++)
                    {
                        m_ChildStageList[i].Update();
                    }
                }
            }
            
            public void SortChildSystem()
            {
                
            }
            
        }
    }
}