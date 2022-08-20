using ET;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

namespace ET
{

	public class UIInventoryViewComponent : Entity
	{
		public UIInventoryAdaptorComponent Adaptor;
		#region 字段声明
		public UnityEngine.GameObject  Item_GameObject;
		public UnityEngine.UI.GridLayoutGroup  Inventory_GridLayoutGroup;
		public UnityEngine.GameObject  Primacy_GameObject;
		public UnityEngine.GameObject  SecondWeapon_GameObject;
		public UnityEngine.GameObject  Coat_GameObject;
		public UnityEngine.GameObject  Pants_GameObject;
		public UnityEngine.GameObject  Shoe_GameObject;
		public UnityEngine.GameObject  Glove_GameObject;
		public UnityEngine.GameObject  Belt_GameObject;
		public UnityEngine.GameObject  Ring_L_GameObject;
		public UnityEngine.GameObject  Ring_R_GameObject;
		public UnityEngine.GameObject  Necklace_GameObject;
		public UnityEngine.UI.Image  Sort_Image;
		public UnityEngine.UI.Button  Sort_Button;
		public UnityEngine.UI.Image  Close_Image;
		public UnityEngine.UI.Button  Close_Button;
		public UnityEngine.Sprite  DefaultSprite_Sprite;

		#endregion

		public void Awake()
		{
			ReferenceCollector rc = GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
			Item_GameObject = rc.Get<UnityEngine.GameObject>("Item"); 
			Inventory_GridLayoutGroup = rc.Get<GameObject>("Inventory").GetComponent<UnityEngine.UI.GridLayoutGroup>(); 
			Primacy_GameObject = rc.Get<UnityEngine.GameObject>("Primacy"); 
			SecondWeapon_GameObject = rc.Get<UnityEngine.GameObject>("SecondWeapon"); 
			Coat_GameObject = rc.Get<UnityEngine.GameObject>("Coat"); 
			Pants_GameObject = rc.Get<UnityEngine.GameObject>("Pants"); 
			Shoe_GameObject = rc.Get<UnityEngine.GameObject>("Shoe"); 
			Glove_GameObject = rc.Get<UnityEngine.GameObject>("Glove"); 
			Belt_GameObject = rc.Get<UnityEngine.GameObject>("Belt"); 
			Ring_L_GameObject = rc.Get<UnityEngine.GameObject>("Ring_L"); 
			Ring_R_GameObject = rc.Get<UnityEngine.GameObject>("Ring_R"); 
			Necklace_GameObject = rc.Get<UnityEngine.GameObject>("Necklace"); 
			Sort_Image = rc.Get<GameObject>("Sort").GetComponent<UnityEngine.UI.Image>(); 
			Sort_Button = rc.Get<GameObject>("Sort").GetComponent<UnityEngine.UI.Button>(); 
			Close_Image = rc.Get<GameObject>("Close").GetComponent<UnityEngine.UI.Image>(); 
			Close_Button = rc.Get<GameObject>("Close").GetComponent<UnityEngine.UI.Button>(); 
			DefaultSprite_Sprite = rc.Get<UnityEngine.Sprite>("DefaultSprite"); 
			InitButtonState();
			Adaptor = EntityFactory.CreateWithParent<UIInventoryAdaptorComponent, ReferenceCollector>(this,rc);
		}
		public void InitButtonState()
		{
			_SortButtonClicked = false;
			_CloseButtonClicked = false;
		}

		bool _SortButtonClicked;

		public void Sort_AddListener(Func<ETTask> action)
		{
			Sort_Button.onClick.RemoveAllListeners();
			Sort_Button.onClick.AddListener(()=>{
				Sort_AddListenerAsync(action).Coroutine();
			});
		}
		async ETVoid Sort_AddListenerAsync(Func<ETTask> action)
		{
			if(_SortButtonClicked) return;
			_SortButtonClicked = true ;
			await action();
			_SortButtonClicked = false ;
		}

		bool _CloseButtonClicked;

		public void Close_AddListener(Func<ETTask> action)
		{
			Close_Button.onClick.RemoveAllListeners();
			Close_Button.onClick.AddListener(()=>{
				Close_AddListenerAsync(action).Coroutine();
			});
		}
		async ETVoid Close_AddListenerAsync(Func<ETTask> action)
		{
			if(_CloseButtonClicked) return;
			_CloseButtonClicked = true ;
			await action();
			_CloseButtonClicked = false ;
		}
	}
}
