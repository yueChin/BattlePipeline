using UnityEngine;

namespace ET
{
    public class ChangeRotation_SyncGameObjectRotation: AEvent<EventIdType.ChangeRotation>
    {
        protected override async ETTask Run(EventIdType.ChangeRotation args)
        {
            GameObjectComponent gameObjectComponent = args.Unit.GetComponent<GameObjectComponent>();
            if (gameObjectComponent == null)
            {
                return;
            }
            Transform transform = gameObjectComponent.GameObject.transform;
            transform.rotation = args.Unit.Rotation;
            await ETTask.CompletedTask;
        }
    }
}