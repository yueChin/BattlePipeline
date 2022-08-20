using System;
using UnityEngine;

namespace ET
{
    public static class BTHelper
    {
        public static void InitBT(this Spell self)
        {
             Init(self, self.SpellConfig.BTConfigName, self.SpellConfig.UpdateInterval);
             //Init(self, self.SpellConfigId.ToString(), self.SpellConfig.EnableBT, self.SpellConfig.UpdateInterval);
        }
        
        public static void Init(Entity entity,  string key , int updateInterval = 0)
        {
            if (string.IsNullOrEmpty(key)) return;
            var btMgrCom = Game.Scene.GetComponent<BehaviorTreeComponent>();


            btMgrCom.TryGet($"ViewBT/{key}", out var viewTree);

            if (!btMgrCom.TryGet($"LogicBT/{key}", out var logicTree))
            {
                Log.Error("无法加载逻辑行为树 " + key);
                return;
            }
            
            entity.RemoveComponent<BTComponent>();
            entity.AddComponent<BTComponent,BehaviorTree,BehaviorTree>(viewTree,logicTree);
            if (updateInterval > 0)
            {
                var ai = entity.GetComponent<BTUpdateComponent>();
                if (ai == null)
                    ai = entity.AddComponent<BTUpdateComponent,int>(updateInterval);
            }
        }

        public static void Execute(BTSwitch @switch, Entity entity)
        {
            ExecuteAsync(@switch,entity).Coroutine();
        }

        public static async ETTask ExecuteAsync(BTSwitch @switch, Entity entity)
        {
            if (entity.IsDisposed) return;
            //  var btMgrCom = Game.Scene.GetComponent<BehaviorTreeComponent>();
            var btCom = entity.GetComponent<BTComponent>();
            if (btCom == null)
            {
                return;
            }
            if (btCom.viewTree != null)
            {
                await Run(@switch, entity, btCom.viewTree);
            }
            if (btCom.logicTree != null)
            {
                await Run(@switch, entity, btCom.logicTree);
            }
        }

        public static async ETTask Run(BTSwitch @switch, Entity entity, BehaviorTree tree)
        {
            long instanceId = entity.InstanceId;
            if (entity.IsDisposed) return;
            //using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.BehaviorTree, instanceId + (int)@switch))
            {
                if (instanceId != entity.InstanceId) return;
                using (BTEnv env = EntityFactory.CreateWithParent<BTEnv>(entity))
                {

                    env.Add<Entity>(BTEnvKey.Entity, entity);
                    env.Add<long>(BTEnvKey.EntityInstanceId, entity.InstanceId);
                    env.Add(BTEnvKey.Switch, @switch);

                    //if (@switch == BTSwitch.UnitUpdate)
                    //    env.Add(BTEnvKey.AI, true);

                    try
                    {
                        await RunNode(tree.RootNode, env);
                    }
                    catch (Exception e)
                    {
                        Log.Error(e.ToString());
                    }
                }
            }
        }

        public static async ETTask<bool> RunNode(Node node,BTEnv env)
        {
            //if (env.Get<bool>(BTEnvKey.AI))
            //    await env.TimerComponent().WaitAsync(0);
            return await BehaviorTreeComponent.Instance.AllNodeHandlers[node.GetType()].Execute(node, env);
        }
    }
}
