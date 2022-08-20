

namespace ET
{
	public class AppStartInitFinish_RemoveLoginUI: AEvent<EventIdType.AppStartInitFinish>
	{
		protected override async ETTask Run(EventIdType.AppStartInitFinish args)
		{
			await UIHelper.Create(args.Scene, UIType.UILogin);
		}
	}
}
