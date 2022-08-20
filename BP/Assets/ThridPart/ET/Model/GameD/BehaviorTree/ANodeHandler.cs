using System;

namespace ET
{
    [BehaviorTree]
    public abstract class ANodeHandler<T>: INodeHandler where T: Node
    {
        public abstract ETTask<bool> Run(T node, BTEnv env);

        public async ETTask<bool> Execute(Node node, BTEnv env)
        {
            T t = node as T;
            var entity = env.Get<Entity>(BTEnvKey.Entity);
            var instanceId = env.Get<long>(BTEnvKey.EntityInstanceId);
            if (entity.IsDisposed || entity.InstanceId != instanceId) return false;
            return await this.Run(t, env);
        }

        public Type NodeType
        {
            get
            {
                return typeof (T);
            }
        }
    }
}