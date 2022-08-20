using Cinemachine;
using UnityEngine;

namespace ET
{
    public class NormalBattleCameraComponent : Entity
    {
        public CinemachineVirtualCamera Camera;
        public Transform oldFollow;
        
        //屏幕边缘四个矩形  
        public Rect RectUp;  
        public Rect RectDown;  
        public Rect RectLeft;  
        public Rect RectRight;

        public float MoveSpeedY = 20; // todo: 后续读玩家设置
        public float MoveSpeedX = 30;

        public Vector3 InitPos;
        
        public float MaxFov = 50;
        public float MinFov = 30;
    }
}