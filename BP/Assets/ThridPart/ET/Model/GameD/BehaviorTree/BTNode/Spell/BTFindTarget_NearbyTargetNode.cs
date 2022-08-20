using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    // 逻辑就是以Caster为释放者,寻找以Target为中心的扇形范围内的单位, 友好度以Caster来判断
    [Node(NodeClassifyType.Action)]
    public class BTFindTarget_NearbyTargetNode : Node
    {
        [NodeField]
        public float Range;
        [NodeField]
        public bool Forward = true; // false就是后方为中心了,以Target为准
        [NodeField]
        public float HalfTheta = 180; // 以中心方向,向两边展开的角度θ的Cos值, -1代表两边展开180度,也就是一个圆,0代表两边展开90度
        [NodeField]
        public bool FindFriend; // 是否获取友方,以Caster来判断友好度
        [NodeInput(typeof (Unit))]
        public string Caster;
        [NodeInput(typeof (Unit))]
        public string Target; // 寻找的范围中心
        [NodeOutput(typeof (List<long>))]
        public string Results;
    }
}