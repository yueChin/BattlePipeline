using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace ET
{

    public class NormalBattleCameraComponentAwakeSystem : AwakeSystem<NormalBattleCameraComponent>
    {
        public override void Awake(NormalBattleCameraComponent self)
        {
            var cam = Camera.main.gameObject.GetComponent<ReferenceCollector>().Get<GameObject>("Cam");
            self.Camera = cam.GetComponent<CinemachineVirtualCamera>();
            float RectSizeY = 150f; //矩形大小  
            float RectSizeX = 200f; //矩形大小 
            
            self.RectUp = new Rect(0,Screen.height-RectSizeY,Screen.width,Screen.height);  
            self.RectDown = new Rect(0,0,Screen.width,RectSizeY);  
            self.RectLeft = new Rect(0,0,RectSizeX,Screen.width);  
            self.RectRight = new Rect(Screen.width-RectSizeX,0,Screen.width,Screen.height);

            self.InitPos = self.Camera.transform.position;
        }
    }

    public class NormalBattleCameraComponentDestroySystem : DestroySystem<NormalBattleCameraComponent>
    {
        public override void Destroy(NormalBattleCameraComponent self)
        {
        }
    }
    
    public class NormalBattleCameraComponentLateUpdateSystem : LateUpdateSystem<NormalBattleCameraComponent>
    {
        public override void LateUpdate(NormalBattleCameraComponent self)
        {
            self.LateUpdate();
        }
    }

    public static class NormalBattleCameraComponentEx
    {
        public static void LateUpdate(this NormalBattleCameraComponent self)
        {
            // if (Input.GetKeyDown(KeyCode.Space))
            // {
            //     if (self.Camera.Follow == null)
            //     {
            //         self.SetFollow(self.oldFollow);
            //     }
            //     else
            //     {
            //         self.SetFollow(null);
            //     }
            // }
            self.TestLogic();
            
            self.HandleScroll();

            // if (self.Camera.Follow != null)
            //     return;
            // if (self.RectUp.Contains(Input.mousePosition))
            // {
            //     self.MoveCam(Vector3.forward,self.MoveSpeedY);
            // }
            //
            // if (self.RectDown.Contains(Input.mousePosition))
            // {
            //     self.MoveCam(Vector3.back,self.MoveSpeedY);
            // }
            //
            // if (self.RectLeft.Contains(Input.mousePosition))
            // {
            //     self.MoveCam(Vector3.left,self.MoveSpeedX);
            // }
            //
            // if (self.RectRight.Contains(Input.mousePosition))
            // {
            //     self.MoveCam(Vector3.right,self.MoveSpeedX);
            //
            // }
        }

        static void TestLogic(this NormalBattleCameraComponent self)
        {
            var myUnit = self.CurrScene().GetMyUnit();
            if (Input.GetKeyDown(KeyCode.T))
            {
                if (myUnit.GetComponent<InventoryComponent>().Pos2Item.Count > 0)
                {
                    foreach (var v in myUnit.GetComponent<InventoryComponent>().Pos2Item)
                    {
                        InventoryHelper.Discard(myUnit.GetComponent<InventoryComponent>(), v.Value.Id).Coroutine();
                        break;
                    }
                }
            }
            
            

            if (Input.GetKeyDown(KeyCode.Space))
            {
                foreach (var v in self.Domain.GetComponent<UnitComponent>().idUnits)
                {
                    if(v.Value.Config.UnitType != (int) UnitType.Drop)
                        continue;
                    DropHelper.PickUp(myUnit,v.Key).Coroutine();
                    break;
                }
            }



            var hitPoint = Vector3.zero;

   
            
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 1000, LayerMask.GetMask("Map")))
                {
                    hitPoint = hit.point;
                }
                else
                {
                    hitPoint = myUnit.Position + myUnit.Forward;
                }
                
                var ret = SpellHelper.CheckCond(myUnit, (int) SpellIDConst.Spear01);
                if (ret != 0)
                {
                   // Log.Debug($"当前不可使用技能{ret}");
                }
                else
                {
                    var spell = SpellFactory.SimpleCreate(myUnit, (int) SpellIDConst.Spear01);
                    ret = SpellHelper.Cast(spell,hitPoint);
                  //  Log.Debug($"使用技能，结果 {ret}");   
                }
            }

     
            if (Input.GetKeyDown(KeyCode.W))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 1000, LayerMask.GetMask("Map")))
                {
                    hitPoint = hit.point;
                }
                else
                {
                    hitPoint = myUnit.Position + myUnit.Forward;
                }
                
                var ret = SpellHelper.CheckCond(myUnit, 1005);
                if (ret != 0)
                {
                    // Log.Debug($"当前不可使用技能{ret}");
                }
                else
                {
                    var spell = SpellFactory.SimpleCreate(myUnit, 1005);
                    ret = SpellHelper.Cast(spell,hitPoint);
                    //  Log.Debug($"使用技能，结果 {ret}");   
                }
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                var ui = self.Domain.GetComponent<UIComponent>().Get(UIType.UIInventory);
                if (ui == null)
                {
                    self.Domain.GetComponent<UIComponent>().CreateOrGet(UIType.UIInventory).Coroutine();
                }
                else
                {
                    self.Domain.GetComponent<UIComponent>().Remove(UIType.UIInventory);
                }
            }
            
            if (Input.GetKeyDown(KeyCode.M))
            {
                var ui = self.Domain.GetComponent<UIComponent>().Get(UIType.UIMap);
                if (ui == null)
                {
                    self.Domain.GetComponent<UIComponent>().CreateOrGet(UIType.UIMap).Coroutine();
                }
                else
                {
                    self.Domain.GetComponent<UIComponent>().Remove(UIType.UIMap);
                }
            }
        }

        static void HandleScroll(this NormalBattleCameraComponent self)
        {
            var value = Input.GetAxis("Mouse ScrollWheel");
            if (Mathf.Abs(value) < 0.01f)
                return;
            var addSpeed = self.MaxFov - self.MinFov;

            var fov = self.Camera.m_Lens.FieldOfView;
            
          
            fov += value * addSpeed;
            fov = Mathf.Clamp(fov, self.MinFov, self.MaxFov);

            self.Camera.m_Lens.FieldOfView = fov;
        }

        static void MoveCam(this NormalBattleCameraComponent self,Vector3 dir,float moveSpeed)
        {
            var trans = self.Camera.transform;
            trans.position += dir * moveSpeed * Time.deltaTime;
        }
        
        public static void SetFollowWithInit(this NormalBattleCameraComponent self, Transform trans)
        {
            self.oldFollow = trans;
            self.SetFollow(trans);
        }

        public static void SetFollow(this NormalBattleCameraComponent self, Transform trans)
        {
            self.Camera.Follow = trans;
            self.Camera.LookAt = trans;
        }


    }
}