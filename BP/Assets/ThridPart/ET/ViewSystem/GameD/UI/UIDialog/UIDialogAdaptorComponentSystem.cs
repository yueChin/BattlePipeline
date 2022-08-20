using ET;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

namespace ET
{
	[ObjectSystem]
	public class UIDialogAdaptorComponentAwakeSystem : AwakeSystem<UIDialogAdaptorComponent,ReferenceCollector>
	{
		public override void Awake(UIDialogAdaptorComponent self,ReferenceCollector rc)
		{
			self.Awake(rc);
		}
	}
	[ObjectSystem]
	public class UIDialogAdaptorComponentDestroySystem : DestroySystem<UIDialogAdaptorComponent>
	{
		public override void Destroy(UIDialogAdaptorComponent self)
		{
			
		}
	}

	public static class UIDialogAdaptorComponentSystem
	{
		public static void Awake(this UIDialogAdaptorComponent self,ReferenceCollector rc)
		{
		}
	}
}
