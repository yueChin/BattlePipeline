using UnityEngine;

namespace ET
{
    public enum BindPointType
    {
        Head,
        BulletPoint1,
        BulletPoint2,
    }

    public class BindPointConfig : MonoBehaviour
    {
        public Transform Head;
        public Transform Weapon_L;
        public Transform Weapon_R;
        public Transform BulletPoint_1;
        public Transform BulletPoint_2;
    }
}