namespace ET
{
    public class LoadingFinishEvent_RemoveLoadingUI : AEvent<EventIdType.LoadingFinish>
    {
        protected override async ETTask Run(EventIdType.LoadingFinish args)
        {
            await UIHelper.Create(args.Scene, UIType.UILoading);
        }
    }
}
