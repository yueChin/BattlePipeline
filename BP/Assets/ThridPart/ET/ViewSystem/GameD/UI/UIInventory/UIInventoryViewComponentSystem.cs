using ET;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

namespace ET
{
	[ObjectSystem]
	public class UIInventoryViewComponentAwakeSystem : AwakeSystem<UIInventoryViewComponent>
	{
		public override void Awake(UIInventoryViewComponent self)
		{
			self.Awake();
		}
	}
	[ObjectSystem]
	public class UIInventoryViewComponentDestroySystem : DestroySystem<UIInventoryViewComponent>
	{
		public override void Destroy(UIInventoryViewComponent self)
		{

			self.Adaptor = null;
			self.Item_GameObject = null;
			self.Inventory_GridLayoutGroup = null;
			self.Primacy_GameObject = null;
			self.SecondWeapon_GameObject = null;
			self.Coat_GameObject = null;
			self.Pants_GameObject = null;
			self.Shoe_GameObject = null;
			self.Glove_GameObject = null;
			self.Belt_GameObject = null;
			self.Ring_L_GameObject = null;
			self.Ring_R_GameObject = null;
			self.Necklace_GameObject = null;
			self.Sort_Image = null;
			self.Sort_Button = null;
			self.Close_Image = null;
			self.Close_Button = null;
			self.DefaultSprite_Sprite = null;
		}
	}
}
