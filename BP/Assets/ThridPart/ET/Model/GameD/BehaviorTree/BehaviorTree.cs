using UnityEngine;

namespace ET
{
    [System.Serializable]
	public class BehaviorTree
    {
        public long Id;
        public Node RootNode;
        public string Name;
	}
}