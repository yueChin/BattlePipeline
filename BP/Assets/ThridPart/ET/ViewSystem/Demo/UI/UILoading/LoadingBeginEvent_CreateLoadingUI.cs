using UnityEngine;

namespace ET
{
    public class LoadingBeginEvent_CreateLoadingUI : AEvent<EventIdType.LoadingBegin>
    {
        protected override async ETTask Run(EventIdType.LoadingBegin args)
        {
            await UIHelper.Create(args.Scene, UIType.UILoading);
        }
    }
}
