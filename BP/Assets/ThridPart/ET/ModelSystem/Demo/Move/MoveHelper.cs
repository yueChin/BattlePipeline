using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    public static class MoveHelper
    {
        // 可以多次调用，多次调用的话会取消上一次的协程
        public static async ETTask<int> MoveToAsync(this Unit unit, Vector3 targetPos,float dis = 0, ETCancellationToken cancellationToken = null)
        {
            var moveCom = unit.GetComponent<MoveComponent>();
            return await moveCom.MoveTo(targetPos,dis,cancellationToken);
        }
    }
}