using System;
using UnityEngine;

namespace ET
{
    public class AutoDisable : MonoBehaviour
    {
        [Header("s秒")]
        public float time;

        private void OnEnable()
        {
            GameObject.Destroy(this,this.time);
        }
    }
}