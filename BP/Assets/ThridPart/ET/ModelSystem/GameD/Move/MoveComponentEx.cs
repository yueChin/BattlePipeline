using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;

namespace ET
{

    public class MoveComponentAwakeSystem : AwakeSystem<MoveComponent>
    {
        public override void Awake(MoveComponent self)
        {
        }
    }
    
    public class MoveComponentUpdateSystem : UpdateSystem<MoveComponent>
    {
        public override void Update(MoveComponent self)
        {
            if (!self.IsMove)
                return;
            var target = self.Target;
            var unit = self.GetParent<Unit>();
            //  var speed = unit.GetComponent<NumericComponent>().GetAsFloat(NumericType.MoveSpeed);
            var speed = 6;
            unit.Position = Vector3.MoveTowards(unit.Position, target, speed * Time.deltaTime);
            if (Vector3.SqrMagnitude(unit.Position - self.Target) <= 0.01f)
            {
                unit.Position = self.Target;
                self.Continue();
            }
        }
    }

    public class MoveComponentDestroySystem : DestroySystem<MoveComponent>
    {
        public override void Destroy(MoveComponent self)
        {
            self.IsMove = false;
            var task = self.task;
            self.task = null;
            task?.SetResult(ErrorCode.ERR_Cancel);
        }
    }

    public static class MoveComponentEx
    {
        public static async ETTask<int> MoveTo(this MoveComponent self,Vector3 target,float dis = 0,ETCancellationToken token = null)
        {
            self.task?.SetResult(ErrorCode.ERR_Cancel); // todo: 返回移动被取消
            self.task = null;
            if (!self.Parent.GetComponent<PathFindingComponent>().FindPath(target,dis))
            {
                return ErrorCode.ERR_Cancel; // todo: 返回无法移动过去
            }
            self.dis = dis;
            var path = self.Parent.GetComponent<PathFindingComponent>().Path.corners;
           // Log.Debug($"寻路，路径{path.Length}  终点{target} Dis {dis}");
            var unit = self.GetParent<Unit>();
            Game.EventSystem.Run(new EventIdType.MoveStart(){Unit = unit}).Coroutine();
            self.IsMove = true;
            for (int i = 0; i < path.Length; i++)
            {
                self.Target = path[i];
                if (i == path.Length - 1 && dis > 0.1f)
                {
                    self.Target = self.Target - Vector3.Normalize(self.Target - self.GetParent<Unit>().Position) * dis;
                }

                self.task = ETTask<int>.Create();
                //token?.Add(()=>self.task?.SetResult(ErrorCode.ERR_Cancel));
                var dir = self.Target - unit.Position;
                if (dir.sqrMagnitude > 0.1f)
                    unit.Forward = dir.normalized;
                var ret = await self.task;
                if (ret != 0)
                {
                    return ret;
                }
            }
            self.Stop(0);


            return 0;
        }

        public static void Continue(this MoveComponent self)
        {
            var task = self.task;
            self.task = null;
            task?.SetResult(0);
        }

        public static void Stop(this MoveComponent self,int errorCode)
        {
            Game.EventSystem.Run(new EventIdType.MoveStop() { Unit = self.GetParent<Unit>() }).Coroutine();
            self.IsMove = false;
            var task = self.task;
            self.task = null;
            task?.SetResult(0);
        }
    }
}