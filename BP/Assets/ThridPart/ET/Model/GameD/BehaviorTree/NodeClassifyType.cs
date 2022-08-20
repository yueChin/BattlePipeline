using System;

namespace ET
{
	[Flags]
	public enum NodeClassifyType : byte
	{
		Composite =  1<< 1,
		Action = 1<< 2,
		Condition = 1<<3,
		Root = 1<<4,
		DataTransform = 1<<5 ,
        Error  = 1<<6
	}
}