using UnityEngine;

namespace ET
{
    public enum SceneObjType
    {
        Point,
        Region,
    }

    public class SceneObj : Entity
    {
        public SceneObjType Type;
        public Vector3 Pos;
        public Quaternion Rot;
    }
}