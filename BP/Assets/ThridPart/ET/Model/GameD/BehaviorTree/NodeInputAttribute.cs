using System;

namespace ET
{
	[AttributeUsage(AttributeTargets.Field)]
	public class NodeInputAttribute: BaseAttribute
	{
		public Type envKeyType;
		public NodeInputAttribute(Type _envKeyType)
		{
			envKeyType = _envKeyType;
		}
	}
}