using ET;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

namespace ET
{
	[ObjectSystem]
	public class UIBattleHudViewComponentAwakeSystem : AwakeSystem<UIBattleHudViewComponent>
	{
		public override void Awake(UIBattleHudViewComponent self)
		{
			self.Awake();
		}
	}
	[ObjectSystem]
	public class UIBattleHudViewComponentDestroySystem : DestroySystem<UIBattleHudViewComponent>
	{
		public override void Destroy(UIBattleHudViewComponent self)
		{

			self.Adaptor = null;
			self.TempTips_Text = null;
			self.TempHPBar_GameObject = null;
		}
	}
}
