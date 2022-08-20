using ET;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

namespace ET
{

	public class UIMapViewComponent : Entity
	{
		public UIMapAdaptorComponent Adaptor;
		#region 字段声明
		public UnityEngine.UI.Image  Map_Image;
		public UnityEngine.UI.Image  TempBtn_Image;
		public UnityEngine.UI.Button  TempBtn_Button;
		public UnityEngine.UI.Image  Viewport_Image;
		public UnityEngine.UI.Mask  Viewport_Mask;
		public UnityEngine.Sprite  NotActive_Sprite;
		public UnityEngine.Sprite  Active_Sprite;
		public UnityEngine.Sprite  CurrPos_Sprite;

		#endregion

		public void Awake()
		{
			ReferenceCollector rc = GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
			Map_Image = rc.Get<GameObject>("Map").GetComponent<UnityEngine.UI.Image>(); 
			TempBtn_Image = rc.Get<GameObject>("TempBtn").GetComponent<UnityEngine.UI.Image>(); 
			TempBtn_Button = rc.Get<GameObject>("TempBtn").GetComponent<UnityEngine.UI.Button>(); 
			Viewport_Image = rc.Get<GameObject>("Viewport").GetComponent<UnityEngine.UI.Image>(); 
			Viewport_Mask = rc.Get<GameObject>("Viewport").GetComponent<UnityEngine.UI.Mask>(); 
			NotActive_Sprite = rc.Get<UnityEngine.Sprite>("NotActive"); 
			Active_Sprite = rc.Get<UnityEngine.Sprite>("Active"); 
			CurrPos_Sprite = rc.Get<UnityEngine.Sprite>("CurrPos"); 
			InitButtonState();
			Adaptor = EntityFactory.CreateWithParent<UIMapAdaptorComponent, ReferenceCollector>(this,rc);
		}
		public void InitButtonState()
		{
			_TempBtnButtonClicked = false;
		}

		bool _TempBtnButtonClicked;

		public void TempBtn_AddListener(Func<ETTask> action)
		{
			TempBtn_Button.onClick.RemoveAllListeners();
			TempBtn_Button.onClick.AddListener(()=>{
				TempBtn_AddListenerAsync(action).Coroutine();
			});
		}
		async ETVoid TempBtn_AddListenerAsync(Func<ETTask> action)
		{
			if(_TempBtnButtonClicked) return;
			_TempBtnButtonClicked = true ;
			await action();
			_TempBtnButtonClicked = false ;
		}
	}
}
