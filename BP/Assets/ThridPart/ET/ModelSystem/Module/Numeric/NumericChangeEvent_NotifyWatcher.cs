namespace ET
{
	// 分发数值监听
	public class NumericChangeEvent_NotifyWatcher: AEvent<EventIdType.NumbericChange>
	{
		protected override async ETTask Run(EventIdType.NumbericChange args)
		{
			NumericWatcherComponent.Instance.Run(args.Unit, args.NumericType, args.Old, args.New);
			await ETTask.CompletedTask;
		}
	}
}
