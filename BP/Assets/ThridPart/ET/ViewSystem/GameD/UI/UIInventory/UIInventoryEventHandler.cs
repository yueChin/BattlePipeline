using ET;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

namespace ET
{

	[UIEvent(UIType.UIInventory)]

	public class UIInventoryEventHandler : AUIEvent
	{
		public override async ETTask OnCreate(UI ui)
		{
			ui.AddComponent<UIInventoryViewComponent>();
			await ETTask.CompletedTask;
		}
		public override void OnRemove(UI ui)
		{

		}
	}
}
