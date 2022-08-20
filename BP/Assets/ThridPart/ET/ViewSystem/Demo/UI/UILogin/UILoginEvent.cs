using System;
using UnityEngine;

namespace ET
{
    [UIEvent(UIType.UILogin)]
    public class UILoginEvent: AUIEvent
    {
        public override async ETTask OnCreate(UI ui)
        {
            ui.AddComponent<UILoginComponent>();
            await ETTask.CompletedTask;
        }

        public override void OnRemove(UI ui)
        {
            
        }
    }
}