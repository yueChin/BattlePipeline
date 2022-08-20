namespace ET
{
    [ObjectSystem]
    public class PlotDestroySystem : DestroySystem<Plot>
    {
        public override void Destroy(Plot self)
        {
            var tcs = self.tcs;
            self.tcs = null;
            tcs?.SetResult();
        }
    }

    [ObjectSystem]
    public class PlotStartSystem : AwakeSystem<Plot,int>
    {
        public override void Awake(Plot self,int ConfigId)
        {
            self.ConfigId = ConfigId;
        }
    }

    public static class PlotEx
    {
        public static async ETTask Start(this Plot self)
        {
            var config = PlotConfigCategory.Instance.Get(self.ConfigId);
            if (!config.UseBT)
            {
                foreach (var v in config.DialogQueue)
                {
                    var dialog = EntityFactory.CreateWithParent<Dialog, int>(self, v);
                    await dialog.Start();
                    if (self.IsDisposed)
                        return;
                }
            }
            else
            {
                //todo: 走行为树
            }
        }
    }
}