using System.Collections.Generic;

namespace Pipeline
{
    public partial class GameLoop
    {
        private readonly List<Stage> m_StageList = new List<Stage>();
        private readonly List<Stage> m_FixedStageList = new List<Stage>();

        public void Init()
        {
            m_StageList.Add(new BeforeUpdateStage());
            m_StageList.Add(new UpdateStage());
            m_StageList.Add(new AfterUpdateStage());
            
            m_FixedStageList.Add(new BeforeFixedUpdateStage());
            m_FixedStageList.Add(new FixedUpdateStage());
            m_FixedStageList.Add(new AfterFixedUpdateStage());
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