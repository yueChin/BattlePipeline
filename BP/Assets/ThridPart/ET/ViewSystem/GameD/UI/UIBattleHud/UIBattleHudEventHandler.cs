using ET;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

namespace ET
{

	[UIEvent(UIType.UIBattleHud)]

	public class UIBattleHudEventHandler : AUIEvent
	{
		public override async ETTask OnCreate(UI ui)
		{
			ui.AddComponent<UIBattleHudViewComponent>();
			await ETTask.CompletedTask;
		}
		public override void OnRemove(UI ui)
		{

		}
	}
}
