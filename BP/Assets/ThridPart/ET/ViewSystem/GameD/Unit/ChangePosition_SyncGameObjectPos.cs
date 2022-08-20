using UnityEngine;

namespace ET
{
    public class ChangePosition_SyncGameObjectPos: AEvent<EventIdType.ChangePosition>
    {
        protected override async ETTask Run(EventIdType.ChangePosition args)
        {
            GameObjectComponent gameObjectComponent = args.Unit.GetComponent<GameObjectComponent>();
            if (gameObjectComponent == null)
            {
                return;
            }
            Transform transform = gameObjectComponent.GameObject.transform;
            transform.position = args.Unit.Position;
            await ETTask.CompletedTask;
        }
    }
}