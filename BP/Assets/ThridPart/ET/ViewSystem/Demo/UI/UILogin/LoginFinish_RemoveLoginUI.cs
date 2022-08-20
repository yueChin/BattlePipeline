

namespace ET
{
	public class LoginFinish_RemoveLoginUI: AEvent<EventIdType.LoginFinish>
	{
		protected override async ETTask Run(EventIdType.LoginFinish args)
		{
			await UIHelper.Remove(args.ZoneScene.CurrScene(), UIType.UILogin);
		}
	}
}
