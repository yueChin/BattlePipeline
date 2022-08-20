using System.Collections.Generic;

namespace ET
{
    [Node(NodeClassifyType.Action)]
    public class BTFindTarget_BoxCastNode : Node
    {
        [NodeField]
        public float Width;
        [NodeField]
        public float Length;
        [NodeField]
        public bool Forward = true; // false就是后方为中心了,以Target为准
        [NodeField]
        public bool FindFriend; // 是否获取友方,以Caster来判断友好度

        [NodeField]
        public int FindNum = 1;
        [NodeInput(typeof (Unit))]
        public string Caster;
        [NodeInput(typeof (Unit))]
        public string Target; // 寻找的范围中心
        [NodeOutput(typeof (List<long>))]
        public string Results;
    }
}