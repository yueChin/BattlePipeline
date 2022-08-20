using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ET
{

    public class PathFindingComponentAwakeSystem : AwakeSystem<PathFindingComponent,GameObject>
    {
        public override void Awake(PathFindingComponent self,GameObject go)
        {

        }
    }

    public class PathFindingComponentDestroySystem : DestroySystem<PathFindingComponent>
    {
        public override void Destroy(PathFindingComponent self)
        {
        }
    }

    public static class PathFindingComponentEx
    {

        public static bool FindPath(this PathFindingComponent self,Vector3 targetPoint,float dis)
        {
           // self.Agent.stoppingDistance = dis;
           bool ret = NavMesh.CalculatePath(self.GetParent<Unit>().Position, targetPoint,NavMesh.AllAreas, self.Path);
            if (ret)
            {
                //self.Path.GetCornersNonAlloc(self.Cornors);
            }

            return ret;
        }
        
    }
}