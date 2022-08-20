using UnityEngine;

namespace ET
{
    public class MoveComponent : Entity
    {
        public Vector3 Target;
        public float dis;
        public ETTask<int> task;
        public bool IsMove;
    }
}