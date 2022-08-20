using ET;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

namespace ET
{
	[ObjectSystem]
	public class UIDialogViewComponentAwakeSystem : AwakeSystem<UIDialogViewComponent>
	{
		public override void Awake(UIDialogViewComponent self)
		{
			self.Awake();
		}
	}
	[ObjectSystem]
	public class UIDialogViewComponentDestroySystem : DestroySystem<UIDialogViewComponent>
	{
		public override void Destroy(UIDialogViewComponent self)
		{

			self.Adaptor = null;
			self.Bg_RawImage = null;
			self.RoleTrans_GameObject = null;
			self.RoleItem_Image = null;
			self.Speaker_Text = null;
			self.Content_Text = null;
			self.Option_Image = null;
			self.Option_Button = null;
			self.OpParent_GridLayoutGroup = null;
		}
	}
}
