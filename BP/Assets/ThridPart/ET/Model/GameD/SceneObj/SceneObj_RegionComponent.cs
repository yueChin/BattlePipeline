
namespace ET
{

    public class SceneObj_RegionComponent : Entity,ISerializeToEntity
    {
        public SceneObjRegionMonoShape Shape;
        public int X ;
        public int Y ;

#if !SERVER
        public void Init(SceneObj_RegionConfig config)
        {
            this.Shape = config.sceneObjRegionMonoType;
            this.X = (int) (config.PropertyX * 1000);
            this.Y = (int) (config.PropertyZ * 1000);

            if (this.X == 0)
                this.X = 1;
            if (this.Y == 0)
                this.Y = 1;
        }
#endif
    }
}