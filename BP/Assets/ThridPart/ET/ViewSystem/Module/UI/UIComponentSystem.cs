using System.Collections.Generic;
using JetBrains.Annotations;

namespace ET
{
	public class UIComponentAwakeSystem : AwakeSystem<UIComponent>
	{
		public override void Awake(UIComponent self)
		{
		}
	}
	
	/// <summary>
	/// 管理Scene上的UI
	/// </summary>
	public static class UIComponentSystem
	{
		public static async ETTask<UI> CreateOrGet(this UIComponent self, string uiType)
		{
			using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.CreateUI, uiType.GetHashCode()))
			{
				if (self.IsDisposed)
					return null;
				UI ui = self.Get(uiType);
				if (ui != null)
					return ui;
				if (self.IsDisposed)
					return null;
				self.UIs.Add(uiType, ui);
				return ui;
			}
		}

		public static void Remove(this UIComponent self, string uiType)
		{
			if (!self.UIs.TryGetValue(uiType, out UI ui))
			{
				return;
			}
			
			
			self.UIs.Remove(uiType);
			ui.Dispose();
		}

		public static UI Get(this UIComponent self, string name)
		{
			UI ui = null;
			self.UIs.TryGetValue(name, out ui);
			return ui;
		}
	}
}