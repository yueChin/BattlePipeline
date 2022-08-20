using System.Collections.Generic;

namespace ET
{
    public class SceneObjCollect : Entity
    {
        public Dictionary<int, SceneObj> AllObjs = new Dictionary<int, SceneObj>();
    }

    public class SceneObjManagerComponent : Entity
    {
        public static SceneObjManagerComponent Instance;
        public Dictionary<string, SceneObjCollect> AllObjs = new Dictionary<string, SceneObjCollect>();

        public SceneObj Get(Scene scene, int id)
        {
            var mapConfig = MapConfigCategory.Instance.GetByName(scene.Name);
            return this.AllObjs[mapConfig.PointConfig].AllObjs[id];
        }

        public Dictionary<int, SceneObj> Get(Scene scene)
        {
            var mapConfig = MapConfigCategory.Instance.GetByName(scene.Name);
            if (!this.AllObjs.ContainsKey(mapConfig.PointConfig))
            {
                return null;
            }

            return this.AllObjs[mapConfig.PointConfig].AllObjs;
        }
    }
}