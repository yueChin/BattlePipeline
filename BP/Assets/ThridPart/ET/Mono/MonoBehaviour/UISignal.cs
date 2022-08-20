using UnityEngine;

namespace ET
{
    
    public enum UISignalType
    {
        /// <summary>
        /// 挂在根节点的物体上,作为公共UI模块.
        /// 这个公共模块作为子物体时,如果根节点的RC组件持有了它的引用,不生成对应的子模块脚本
        /// </summary>
        NoCodeGen,
    }

    public class UISignal: MonoBehaviour
    {
        public UISignalType UISignalType;
    }
}