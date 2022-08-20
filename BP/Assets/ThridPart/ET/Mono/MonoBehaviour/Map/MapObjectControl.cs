using System.IO;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ET
{
    public class MapObjectControl : MonoBehaviour
    {
        public string FileName;

        [ReadOnly]
        public int Index;
        
        [Button("新增Map配置点")]
        void CreateTempBtn()
        {
            Index++;
            var tempBtn = this.transform.Find("TempBtn");
            var go = GameObject.Instantiate(tempBtn.gameObject, this.transform);
            go.name = "Obj_" + Index;
            var mapObj = go.AddComponent<MapObject>();
            mapObj.Id = this.Index;
            mapObj.TransferConfigId = this.Index;
        }
        
        [Button("生成Map配置")]
        void CreateFile()
        {
            var allObjs = this.transform.GetComponentsInChildren<MapObject>();
            if(allObjs == null || allObjs.Length == 0)
                return;
         
        }
        
        
    }
}