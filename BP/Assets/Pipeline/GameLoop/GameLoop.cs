using System.Collections.Generic;
using ECS;

namespace Pipeline
{
    public partial class GameLoop
    {
        private EcsWorld GPWorld;
        private EcsSystems GPSystem;

        public void Init()
        {
            GPWorld = new EcsWorld();
            GPSystem = new EcsSystems(GPWorld);
            GPSystem.InjectSystemToBaseSystem();
        }

        public void Update()
        {
            
        }

        public void FixedUpdate()
        {
            
        }
    }
}