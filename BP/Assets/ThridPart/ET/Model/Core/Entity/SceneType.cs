namespace ET
{
	public enum SceneType
	{
		Process = 0,
		Manager = 1,
		Realm = 2,
		Gate = 3,
		Http = 4,
		Location = 5,
		Map = 6,
		Agent = 7, // 动态分配服
		AgentManager = 8, // 动态分配管理服
		Center = 9, // 中心服
		HTTP = 10,// HTTP服

		// 客户端Model层
		Client = 30,
		Zone = 31,
		Login = 32,
		Robot = 33,
	}
}