using Unity.Collections;
using UnityEngine;

namespace ET
{
    public class MapObject : MonoBehaviour
    {
        [ReadOnly]
        public int Id;

        public int TransferConfigId;
        
#if UNITY_EDITOR
        void OnDrawGizmos()
        {
            if (TransferConfigId == 0) return;
            //var point = UnityEditor.HandleUtility.WorldToGUIPoint(sceneObjMonoMgr.transform.position);
            UnityEditor.Handles.Label(this.transform.position, "传送：" + this.TransferConfigId);
        }
#endif
    }
}