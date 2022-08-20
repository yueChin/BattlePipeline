using System;
using UnityEngine;

namespace ET
{
	[UIEvent(UIType.UILoading)]
    public class UILoadingEvent: AUIEvent
    {
	    public override async ETTask OnCreate(UI ui)
	    {
		    ui.AddComponent<UILoadingComponent>();
		    await ETTask.CompletedTask;
	    }

	    public override void OnRemove(UI uiComponent)
        {
        }
    }
}