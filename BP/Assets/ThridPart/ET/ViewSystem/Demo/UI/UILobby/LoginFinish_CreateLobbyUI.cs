

namespace ET
{
	public class LoginFinish_CreateLobbyUI: AEvent<EventIdType.LoginFinish>
	{
		protected override async ETTask Run(EventIdType.LoginFinish args)
		{
			await UIHelper.Create(args.ZoneScene.CurrScene(), UIType.UILobby);
		}
	}
}
