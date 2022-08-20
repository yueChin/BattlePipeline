namespace ET
{
    public enum CopyType
    {
        InitMap, // 初始副本
        SingleCopy = 1, // 单人副本
        Line = 2, // 公共副本，有分线
        Public = 3, // 公共副本， 单例
        Dungeon = 4, // 多人游戏，临时生成的副本
    }
}