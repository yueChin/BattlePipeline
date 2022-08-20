using ET;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

namespace ET
{

	public class UIDialogViewComponent : Entity
	{
		public UIDialogAdaptorComponent Adaptor;
		#region 字段声明
		public UnityEngine.UI.RawImage  Bg_RawImage;
		public UnityEngine.GameObject  RoleTrans_GameObject;
		public UnityEngine.UI.Image  RoleItem_Image;
		public UnityEngine.UI.Text  Speaker_Text;
		public UnityEngine.UI.Text  Content_Text;
		public UnityEngine.UI.Image  Option_Image;
		public UnityEngine.UI.Button  Option_Button;
		public UnityEngine.UI.GridLayoutGroup  OpParent_GridLayoutGroup;

		#endregion

		public void Awake()
		{
			ReferenceCollector rc = GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
			Bg_RawImage = rc.Get<GameObject>("Bg").GetComponent<UnityEngine.UI.RawImage>(); 
			RoleTrans_GameObject = rc.Get<UnityEngine.GameObject>("RoleTrans"); 
			RoleItem_Image = rc.Get<GameObject>("RoleItem").GetComponent<UnityEngine.UI.Image>(); 
			Speaker_Text = rc.Get<GameObject>("Speaker").GetComponent<UnityEngine.UI.Text>(); 
			Content_Text = rc.Get<GameObject>("Content").GetComponent<UnityEngine.UI.Text>(); 
			Option_Image = rc.Get<GameObject>("Option").GetComponent<UnityEngine.UI.Image>(); 
			Option_Button = rc.Get<GameObject>("Option").GetComponent<UnityEngine.UI.Button>(); 
			OpParent_GridLayoutGroup = rc.Get<GameObject>("OpParent").GetComponent<UnityEngine.UI.GridLayoutGroup>(); 
			InitButtonState();
			Adaptor = EntityFactory.CreateWithParent<UIDialogAdaptorComponent, ReferenceCollector>(this,rc);
		}
		public void InitButtonState()
		{
			_OptionButtonClicked = false;
		}

		bool _OptionButtonClicked;

		public void Option_AddListener(Func<ETTask> action)
		{
			Option_Button.onClick.RemoveAllListeners();
			Option_Button.onClick.AddListener(()=>{
				Option_AddListenerAsync(action).Coroutine();
			});
		}
		async ETVoid Option_AddListenerAsync(Func<ETTask> action)
		{
			if(_OptionButtonClicked) return;
			_OptionButtonClicked = true ;
			await action();
			_OptionButtonClicked = false ;
		}
	}
}
