using UnityEngine;

namespace ET
{
    public static class UnitFactory
    {
        public static async ETTask<Unit> CreateFromProto(Entity domain, UnitInfo unitInfo)
        {
	        
	        UnitComponent unitComponent = domain.GetComponent<UnitComponent>();
	        Unit unit = EntityFactory.CreateWithParentAndId<Unit, int>(unitComponent, unitInfo.UnitId, unitInfo.ConfigId);
	        unit.Position = unitInfo.Pos.ToV3();
	        
	        unit.AddComponent<NumericComponent>();
	        unit.AddComponent<ObjectWait>();

            unitComponent.Add(unit);
            await Game.EventSystem.Run(new EventIdType.AfterUnitCreate() {Unit = unit});
            return unit;
        }

        public static async ETTask<Unit> CreateMyUnitFromProto(Entity domain, UnitInfo unitInfo)
        {
	        UnitComponent unitComponent = domain.GetComponent<UnitComponent>();
	        Unit unit = EntityFactory.CreateWithParentAndId<Unit, int>(unitComponent, unitInfo.UnitId, unitInfo.ConfigId);
	        unit.Position = unitInfo.Pos.ToV3();

	        unit.AddComponent<NumericComponent>();
	        unit.AddComponent<ObjectWait>();
	        unit.AddComponent<SpellComponent>();
	        unit.AddComponent<BuffComponent>();
	        unit.AddComponent<InventoryComponent>();
	        unit.AddComponent<EquipComponent>();
	        
	        Log.Debug("创建主角");
	        unit.GetComponent<NumericComponent>().Set(NumericType.Camp,(int) CampType.Friend);
	        
	        unit.GetComponent<NumericComponent>().InitByLevel(1);
	        

	        unitComponent.Add(unit);
	        unitComponent.MyUnit = unit;
	        await Game.EventSystem.Run(new EventIdType.AfterUnitCreate() {Unit = unit});
	        return unit;
        }

        public static async ETTask<Unit> CreateMonster(Scene scene, int configId, int level,Vector3 pos,Quaternion rot)
        {
	        UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
	        Unit unit = EntityFactory.CreateWithParent<Unit, int>(unitComponent,  configId);
	        Log.Debug($"创建怪物{unit.Id}");
	        unit.Position = pos;
	        unit.Rotation = rot;
	        unit.AddComponent<NumericComponent>().InitByLevel(level);
	        unit.AddComponent<ObjectWait>();
	        unit.AddComponent<SpellComponent>();
	        unit.AddComponent<BuffComponent>();
	        unit.AddComponent<AIHatredComponent>();
	        unit.AddComponent<AIComponent,int>(unit.Config.AIConfig);
	        unit.GetComponent<NumericComponent>().Set(NumericType.Camp,(int) CampType.Enemy);

	        unitComponent.Add(unit);
	        await Game.EventSystem.Run(new EventIdType.AfterUnitCreate() {Unit = unit});
	        return unit;
        }

        public static async ETTask<Unit> CreateUnitFromConfig(Scene scene, SceneObj sceneObj, SceneObj_UnitComponent com)
        {
	        UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
	        Unit unit = EntityFactory.CreateWithParent<Unit, int>(unitComponent,  com.UnitConfigId);
	        Log.Debug($"创建场景配置单位{com.UnitConfigId}");
	        unit.Position = sceneObj.Pos;
	        unit.Rotation = sceneObj.Rot;
	        if (com.Level == 0)
		        com.Level = 1;
	        unit.AddComponent<NumericComponent>().InitByLevel(com.Level);
	        unit.AddComponent<ObjectWait>();
	        unit.AddComponent<AIHatredComponent>();
	        unit.AddComponent<AIComponent,int>(unit.Config.AIConfig);
	        unit.GetComponent<NumericComponent>().Set(NumericType.Camp,com.Camp);

	        unitComponent.Add(unit);
	        await Game.EventSystem.Run(new EventIdType.AfterUnitCreate() {Unit = unit});
	        return unit;
        }
    }
}
