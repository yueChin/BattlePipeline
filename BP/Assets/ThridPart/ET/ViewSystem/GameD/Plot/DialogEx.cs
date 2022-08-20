namespace ET
{
    [ObjectSystem]
    public class DialogDestroySystem : DestroySystem<Dialog>
    {
        public override void Destroy(Dialog self)
        {
            var tcs = self.tcs;
            self.tcs = null;
            tcs?.SetResult();
        }
    }
    
    [ObjectSystem]
    public class DialogStartSystem : AwakeSystem<Dialog,int>
    {
        public override void Awake(Dialog self,int ConfigId)
        {
            self.ConfigId = ConfigId;
        }
    }

    public static class DialogEx
    {
        public static async ETTask Start(this Dialog self)
        {
            //如果不包含选项,直接展示,等待玩家点击或者超时后结束
            // 如果包含选项,这里也要生成选项对应的dialog,然后等待玩家点击对应选项或者超时自动点击
            await ETTask.CompletedTask;
        }
    }
}