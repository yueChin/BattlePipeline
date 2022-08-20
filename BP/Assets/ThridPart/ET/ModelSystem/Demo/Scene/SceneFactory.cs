namespace ET
{
    public static class SceneFactory
    {
        public static async ETTask<Scene> CreateZoneScene(int zone, string name, Entity parent)
        {
            Scene zoneScene = EntitySceneFactory.CreateScene(Game.IdGenerator.GenerateInstanceId(), zone, SceneType.Zone, name, parent);
            zoneScene.AddComponent<ZoneSceneFlagComponent>();
            zoneScene.AddComponent<NetKcpComponent>();
            zoneScene.AddComponent<UnitComponent>();
            await zoneScene.AddComponent<SceneComponent>().InitLoginScene();
            // UI层的初始化
            await Game.EventSystem.Run(new EventIdType.AfterCreateScene() {Scene = zoneScene});
            return zoneScene;
        }

        public static async ETTask<Scene> CreateScene(Entity parent, int mapConfigId)
        {
            var mapConfig = MapConfigCategory.Instance.Get(mapConfigId);
            Scene scene = EntitySceneFactory.CreateScene(Game.IdGenerator.GenerateInstanceId(), parent.DomainZone(), SceneType.Map, mapConfig.SceneName, parent);
            scene.ConfigId = mapConfigId;
            scene.AddComponent<UnitComponent>();
            // UI层的初始化
            await Game.EventSystem.Run(new EventIdType.AfterCreateScene() {Scene = scene});
            return scene;
        }
    }
}