using UnityEngine;

namespace ET
{
    public class SceneObj_UnitConfig : MonoBehaviour,ISceneObjMonoConfig
    {
        public string GetName()
        {
            return "单位生成";
        }

        public int UnitConfigId;
        [Header("0表示绝对中立，一切单位友好，否则就和对应阵营友好，另一方敌对")]
        [Range(-1,1)]
        public int Camp;

        public int Level;
        public int[] Buffs;
        
#if UNITY_EDITOR

        void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(this.transform.localPosition, new Vector3(2, 2, 2));
        }
#endif
    }
}