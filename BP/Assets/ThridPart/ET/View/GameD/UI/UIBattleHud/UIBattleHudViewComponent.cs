using ET;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

namespace ET
{

	public class UIBattleHudViewComponent : Entity
	{
		public UIBattleHudAdaptorComponent Adaptor;
		#region 字段声明
		public UnityEngine.UI.Text  TempTips_Text;
		public UnityEngine.GameObject  TempHPBar_GameObject;

		#endregion

		public void Awake()
		{
			ReferenceCollector rc = GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
			TempTips_Text = rc.Get<GameObject>("TempTips").GetComponent<UnityEngine.UI.Text>(); 
			TempHPBar_GameObject = rc.Get<UnityEngine.GameObject>("TempHPBar"); 
			InitButtonState();
			Adaptor = EntityFactory.CreateWithParent<UIBattleHudAdaptorComponent, ReferenceCollector>(this,rc);
		}
		public void InitButtonState()
		{
		}
	}
}
