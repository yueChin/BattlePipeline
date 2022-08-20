using ET;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

namespace ET
{

	[UIEvent(UIType.UIMap)]

	public class UIMapEventHandler : AUIEvent
	{
		public override async ETTask OnCreate(UI ui)
		{
			ui.AddComponent<UIMapViewComponent>();
			await ETTask.CompletedTask;
		}
		public override void OnRemove(UI ui)
		{

		}
	}
}
