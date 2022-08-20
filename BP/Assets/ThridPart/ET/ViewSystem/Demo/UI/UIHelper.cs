namespace ET
{
    public static class UIHelper
    {
        public static async ETTask<UI> Create(Scene scene, string uiType)
        {
            return await scene.GetComponent<UIComponent>().CreateOrGet(uiType);
        }
        
        public static async ETTask Remove(Scene scene, string uiType)
        {
            scene.GetComponent<UIComponent>().Remove(uiType);
            await ETTask.CompletedTask;
        }
    }
}