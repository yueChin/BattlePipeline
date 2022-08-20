using ET;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

namespace ET
{
	[ObjectSystem]
	public class UIMapAdaptorComponentAwakeSystem : AwakeSystem<UIMapAdaptorComponent,ReferenceCollector>
	{
		public override void Awake(UIMapAdaptorComponent self,ReferenceCollector rc)
		{
			self.Awake(rc);
		}
	}
	[ObjectSystem]
	public class UIMapAdaptorComponentDestroySystem : DestroySystem<UIMapAdaptorComponent>
	{
		public override void Destroy(UIMapAdaptorComponent self)
		{
			
		}
	}

	public static class UIMapAdaptorComponentSystem
	{
		public static void Awake(this UIMapAdaptorComponent self,ReferenceCollector rc)
		{
			self.ViewCom.TempBtn_Button.gameObject.SetActive(false);
			var gos = self.ViewCom.Map_Image.transform.GetComponentsInChildren<MapObject>();
			var scene = self.DomainScene();
			foreach (var v in gos)
			{
				var button = v.GetComponent<Button>();
				button.onClick.AddListener(()=>ClickTransfer(scene,v.TransferConfigId));
			}
		}

		static void ClickTransfer(Scene scene,int configId)
		{
			TransferHelper.RequestTransfer(scene,configId).Coroutine();
		}

	}
}
