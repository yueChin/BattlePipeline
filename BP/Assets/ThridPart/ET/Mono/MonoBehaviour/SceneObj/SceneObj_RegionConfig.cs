using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace ET
{
    public class SceneObj_RegionConfig : MonoBehaviour, ISceneObjMonoConfig
    {
        public SceneObjRegionMonoShape sceneObjRegionMonoType;
        // 如果是Cube,这里面就存着对应轴上的长度,y轴不用
        // 如果是Cylinder,这里的x就存着半径,y无用
        public float PropertyX = 1;
        public float PropertyZ = 1;
        public string GetName()
        {
            return "区域配置";
        }
#if UNITY_EDITOR
        
        void OnDrawGizmos()
        {
            if (PropertyX <=0.01f) return;
            Gizmos.color = Color.red;
            
            switch (sceneObjRegionMonoType)
            {
                case SceneObjRegionMonoShape.Cube:
                    Gizmos.DrawWireCube(this.transform.localPosition, new Vector3(PropertyX,5,PropertyZ));
                    break;
                case SceneObjRegionMonoShape.Cylinder:
                    GizmosHelper.DrawCylinder(transform, Color.red, PropertyX);

                    //Gizmos.DrawWireSphere(this.transform.localPosition, PropertyX);
                    break;
            }
        }
        #endif
    }
}
