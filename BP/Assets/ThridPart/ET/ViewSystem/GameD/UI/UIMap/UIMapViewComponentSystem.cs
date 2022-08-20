using ET;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

namespace ET
{
	[ObjectSystem]
	public class UIMapViewComponentAwakeSystem : AwakeSystem<UIMapViewComponent>
	{
		public override void Awake(UIMapViewComponent self)
		{
			self.Awake();
		}
	}
	[ObjectSystem]
	public class UIMapViewComponentDestroySystem : DestroySystem<UIMapViewComponent>
	{
		public override void Destroy(UIMapViewComponent self)
		{

			self.Adaptor = null;
			self.Map_Image = null;
			self.TempBtn_Image = null;
			self.TempBtn_Button = null;
			self.Viewport_Image = null;
			self.Viewport_Mask = null;
			self.NotActive_Sprite = null;
			self.Active_Sprite = null;
			self.CurrPos_Sprite = null;
		}
	}
}
