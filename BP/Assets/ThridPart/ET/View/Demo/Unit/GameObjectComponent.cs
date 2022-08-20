using UnityEngine;

namespace ET
{
    public class GameObjectComponentAwakeSystem: AwakeSystem<GameObjectComponent,GameObject>
    {
        public override void Awake(GameObjectComponent self,GameObject go)
        {
            self.GameObject = go;
            self.GameObject.AddComponent<EntityGameObject>().obj = self.Parent;
        }
    }

    public class GameObjectComponent: Entity
    {
        public GameObject GameObject;

        public override void Dispose()
        {
            if (IsDisposed)
                return;
            base.Dispose();
            if (GameObject != null)
                UnityEngine.Object.Destroy(GameObject);
        }
    }
}