using System;
using UnityEngine;

namespace ET
{
    [UIEvent(UIType.UILobby)]
    public class UILobbyEvent: AUIEvent
    {
        public override async ETTask OnCreate(UI ui)
        {
            await ETTask.CompletedTask;
            ui.AddComponent<UILobbyComponent>();
        }

        public override void OnRemove(UI uiComponent)
        {
           
        }
    }
}