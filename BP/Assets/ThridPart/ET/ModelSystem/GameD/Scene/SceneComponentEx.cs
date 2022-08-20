using System.Collections.Generic;

namespace ET
{

    public class SceneComponentAwakeSystem : AwakeSystem<SceneComponent>
    {
        public override void Awake(SceneComponent self)
        {
        }
    }

    public class SceneComponentDestroySystem : DestroySystem<SceneComponent>
    {
        public override void Destroy(SceneComponent self)
        {
        }
    }

    public static class SceneComponentEx
    {
        public static async ETTask InitLoginScene(this SceneComponent self)
        {
            await self.ChangeScene((int) MapIDConst.Login);
        }

        public static async ETTask ChangeScene(this SceneComponent self, int mapConfigId)
        {
            self.currScene?.Dispose();
            self.currScene = await SceneFactory.CreateScene(self, mapConfigId);
        }
        

        public static Scene CurrScene(this Entity self)
        {
            return self.ZoneScene().GetComponent<SceneComponent>().currScene;
        }
    }
}