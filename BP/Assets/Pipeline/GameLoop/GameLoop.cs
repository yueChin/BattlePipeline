using System.Collections.Generic;

namespace Pipeline
{
    public partial class GameLoop
    {
        private readonly List<Stage> m_StageList = new List<Stage>();
        private readonly List<Stage> m_FixedStageList = new List<Stage>();
        
        public void Init()
        {
            m_StageList.Add(new Stage());
            m_FixedStageList.Add(new Stage());
        }

        public void Update()
        {
            foreach (Stage stage in m_StageList)
            {
                stage.Update();
            }
        }

        public void FixedUpdate()
        {
            foreach (Stage stage in m_FixedStageList)
            {
                stage.Update();
            }
        }
    }
}