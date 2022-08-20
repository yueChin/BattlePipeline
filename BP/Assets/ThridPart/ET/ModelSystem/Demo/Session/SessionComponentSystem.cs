namespace ET
{
	public class SessionComponentDestroySystem: DestroySystem<SessionComponent>
	{
		public override void Destroy(SessionComponent self)
		{
			self.Session.Dispose();
		}
	}

	public static class SessionComponentEx
	{
		public static Session CurrSession(this Entity self)
		{
			return self.ZoneScene().GetComponent<SessionComponent>().Session;
		}
	}
}
