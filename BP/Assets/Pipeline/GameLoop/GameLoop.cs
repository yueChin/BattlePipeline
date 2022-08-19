using System.Collections.Generic;
using ECS;

namespace Pipeline
{
    public partial class GameLoop
    {
        private EcsWorld m_GpWorld;
        private EcsSystems m_GpSystem;

        private EcsWorld m_PhysicWorld;
        private EcsSystems m_PhysicSystem;
        public void Init()
        {
            m_GpWorld = new EcsWorld();
            m_GpSystem = new EcsSystems(m_GpWorld);
            m_GpSystem.InjectSystemToBaseSystem();

            m_PhysicWorld = new EcsWorld();
            m_PhysicSystem = new EcsSystems(m_PhysicWorld);
            m_PhysicSystem.InjectSystemToBaseSystem(true);
        }

        public void Update()
        {
            
        }

        public void FixedUpdate()
        {
            
        }
    }
}