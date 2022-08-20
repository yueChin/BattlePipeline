using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace ET
{
    public interface ISceneObjMonoConfig
    {
        public string GetName();
    }

    public class SceneObjMonoConfig : MonoBehaviour
    {
        [HideInInspector]
        public string Remark;

        [HideInInspector]
        public long Id;
        
        #if UNITY_EDITOR
        void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(this.transform.position, 0.5f);
            if (string.IsNullOrEmpty(this.Remark)) return;
            //var point = UnityEditor.HandleUtility.WorldToGUIPoint(sceneObjMonoMgr.transform.position);
            UnityEditor.Handles.Label(this.transform.position, this.Remark);
        }
        #endif
    }
}
