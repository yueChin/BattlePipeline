using System.Collections.Generic;
using ECS;

namespace Pipeline
{
    public partial class GameLoop
    {
        private EcsWorld m_GpWorld;
        private EcsWorldSystems m_GpSystem;

        private EcsWorld m_PhysicWorld;
        private EcsWorldSystems m_PhysicSystem;
        public void Init()
        {
            m_GpWorld = new EcsWorld();
            m_GpSystem = new EcsWorldSystems(m_GpWorld);
            m_GpSystem.InjectSystemToBaseSystem();

            m_PhysicWorld = new EcsWorld();
            m_PhysicSystem = new EcsWorldSystems(m_PhysicWorld);
            m_PhysicSystem.InjectSystemToBaseSystem(true);
        }

        public void Update()
        {
            m_GpSystem.Start();
            m_GpSystem.Run();
            m_GpSystem.Destroy();
        }

        public void FixedUpdate()
        {
            m_PhysicSystem.Start();
            m_PhysicSystem.Run();
            m_PhysicSystem.Destroy();
        }
    }
}