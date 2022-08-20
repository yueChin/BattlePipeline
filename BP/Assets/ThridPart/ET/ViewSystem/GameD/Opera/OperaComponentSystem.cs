using System;
using UnityEngine;

namespace ET
{
    public class OperaComponentAwakeSystem : AwakeSystem<OperaComponent>
    {
        public override void Awake(OperaComponent self)
        {
            self.mapMask = LayerMask.GetMask("Map","Unit");
            self.go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            self.go.SetActive(false);
            self.go.transform.localScale = Vector3.one / 2;
        }
    }

    public class OperaComponentUpdateSystem : UpdateSystem<OperaComponent>
    {
        public override void Update(OperaComponent self)
        {
            self.Update();
        }
    }
    
    public static class OperaComponentSystem
    {
        public static void Update(this OperaComponent self)
        {
            if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (!Physics.Raycast(ray, out hit, 1000, self.mapMask))
                {
                    return;
                }

                var hitTargetGo = hit.collider.gameObject;
                var goCom = hitTargetGo.GetComponent<EntityGameObject>();
                if (goCom!= null && goCom.obj is Unit tarUnit)
                {
                    var myUnit = self.GetParent<Unit>();
                    // // 如果是怪物而且是敌人,那就不管
                    // if (!BattleHelper.IsFriend(myUnit, tarUnit))
                    // {
                    //     return;
                    // }
                    // 在交互距离内就直接触发交互效果
                    // 在交互距离外就寻路靠近
                    //todo: 触发目标的鼠标悬浮效果

                    var dis = tarUnit.Position - myUnit.Position;
                    var radius = AIBattleHelper.GetRadiusDis(myUnit, tarUnit);
                    if (dis.magnitude > radius+1)
                    {
                        Log.Debug($"与目标距离{dis.magnitude},超过交互距离{radius}");
                        self.ClickPoint = tarUnit.Position;
                        self.GetParent<Unit>().MoveToAsync(self.ClickPoint,radius).Coroutine();
                    }
                    else
                    {
                        Log.Debug("触发" + tarUnit.ConfigId + "的交互效果");
                        // 触发对应单位的交互效果
                    }

                    return;
                }


                self.ClickPoint = hit.point;
                self.go.transform.position = hit.point;
                self.Hide();
                self.GetParent<Unit>().MoveToAsync(self.ClickPoint).Coroutine();
            }
            
        }

        public static void Hide(this OperaComponent self)
        {
            if (self.IsDisposed)
                return;
            self.go?.SetActive(true);
            TimerComponent.Instance.Remove(ref self.hideTimer);
            self.hideTimer = TimerComponent.Instance.NewOnceTimer(TimeHelper.ServerNow() + 3000, self.SetActive);
        }

        static void SetActive(this OperaComponent self)
        {
            if (self.IsDisposed)
                return;
            self.go?.SetActive(false);
        }
    }
}