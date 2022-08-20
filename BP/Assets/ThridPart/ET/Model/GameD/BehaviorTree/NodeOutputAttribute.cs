using System;

namespace ET
{
	[AttributeUsage(AttributeTargets.Field)]
	public class NodeOutputAttribute: BaseAttribute
	{
		public Type envKeyType;
		public NodeOutputAttribute(Type _envKeyType)
		{
			envKeyType = _envKeyType;
		}
    }
}