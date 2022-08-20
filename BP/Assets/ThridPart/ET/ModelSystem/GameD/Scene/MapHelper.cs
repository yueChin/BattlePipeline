namespace ET
{
    public static class MapHelper
    {
        public static MapConfig GetMapConfig(this Scene scene)
        {
            return MapConfigCategory.Instance.GetByName(scene.Name);
        }

        public static async ETTask InitMap(Scene scene)
        {
            var mapConfig = scene.GetMapConfig();
            switch (mapConfig.LvType)
            {
                case 1:
                {
                    // 塔防
                    scene.AddComponent<LevelControl,int>(mapConfig.LvParams[0]);
                }
                    break;
            }

            // 创建场景里的单位
            var objs = SceneObjManagerComponent.Instance.Get(scene);
            if (objs != null)
            {
                foreach (var v in objs.Values)
                {
                    var com = v.GetComponent<SceneObj_UnitComponent>();
                    if(com == null)
                        continue;
                    await UnitFactory.CreateUnitFromConfig(scene, v, com);
                }
            }

            await ETTask.CompletedTask;
        }
    }
}