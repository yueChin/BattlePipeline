using System;

namespace ET
{
    [System.Flags]
    public enum NodeClientServerType
    {
        ClientServer = 0xFFFF,
        Client = 1<<1,
        Server = 1<<2,
    }

	[AttributeUsage(AttributeTargets.Class)]
	public class NodeAttribute: Attribute
	{
		public NodeClassifyType ClassifytType { get; private set; }
		public string Desc { get; }
        public NodeClientServerType NodeClientServerType { get; private set; }

        public NodeAttribute(NodeClassifyType classifyType,string desc = "", NodeClientServerType nodeClientServerType = NodeClientServerType.ClientServer)
		{
			this.ClassifytType = classifyType;
            this.NodeClientServerType = nodeClientServerType;
			this.Desc = desc;
		}
	}
}