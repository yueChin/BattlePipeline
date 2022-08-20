using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    public class AppStart_Init: AEvent<EventIdType.AppStart>
    {
        protected override async ETTask Run(EventIdType.AppStart args)
        {
            MongoHelper.Init();
            Game.Scene.AddComponent<TimerComponent>();
            Game.Scene.AddComponent<CoroutineLockComponent>();

            // 加载配置
            //Game.Scene.AddComponent<AssetComponent>();
            Game.Scene.AddComponent<ConfigComponent>();
            await ConfigComponent.Instance.LoadAsync();
            await Game.Scene.AddComponent<BehaviorTreeComponent>().LoadAllBT();
            //await Game.Scene.AddComponent<SceneObjManagerComponent>().LoadAll();
            
            Game.Scene.AddComponent<OpcodeTypeComponent>();
            Game.Scene.AddComponent<MessageDispatcherComponent>();
            
            Game.Scene.AddComponent<NetThreadComponent>();

            Game.Scene.AddComponent<ZoneSceneManagerComponent>();
            
            Game.Scene.AddComponent<GlobalComponent>();

            Game.Scene.AddComponent<AIDispatcherComponent>();
            Game.Scene.AddComponent<NumericWatcherComponent>();
            Game.Scene.AddComponent<BuffEventMgrComponent>();
            Game.Scene.AddComponent<EffectEventMgrComponent>();
            
            Scene zoneScene = await SceneFactory.CreateZoneScene(1, "Game", Game.Scene);
            await Game.EventSystem.Run(new EventIdType.AppStartInitFinish() { Scene = zoneScene.CurrScene() });
        }
    }
}
