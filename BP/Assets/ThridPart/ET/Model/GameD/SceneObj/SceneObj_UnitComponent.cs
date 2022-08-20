namespace ET
{
    public class SceneObj_UnitComponent : Entity,ISerializeToEntity
    {
        public int UnitConfigId;
        public int Camp;
        public int Level;
        public int[] Buffs;
        
#if !SERVER
        public void Init(SceneObj_UnitConfig config)
        {
            this.UnitConfigId = config.UnitConfigId;
            this.Camp = config.Camp;
            this.Level = config.Level;
            this.Buffs = config.Buffs;
        }
#endif
    }
}