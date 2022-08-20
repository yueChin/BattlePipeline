using System.Collections.Generic;

namespace ET
{

    public class LevelControlAwakeSystem : AwakeSystem<LevelControl,int>
    {
        public override void Awake(LevelControl self,int configId)
        {
            self.ConfigId = configId;
            self.NextWave();
        }
    }

    public class LevelControlDestroySystem : DestroySystem<LevelControl>
    {
        public override void Destroy(LevelControl self)
        {
            TimerComponent.Instance.Remove(ref self.nextWaveTimer);
        }
    }

    public static class LevelControlEx
    {
        public static void NextWave(this LevelControl self)
        {
            var levelConfig = TDLevelConfigCategory.Instance.Get(self.ConfigId);
            var time = levelConfig.WaveInterval[self.CurrWaveIndex];
            Log.Debug($"第一波怪物将于{time}ms后刷新");
            TimerComponent.Instance.Remove(ref self.nextWaveTimer);
            self.nextWaveTimer = TimerComponent.Instance.NewOnceTimer(TimeHelper.ServerNow() + time, self.EnterWave);
        }

        public static void Skip(this LevelControl self)
        {
            TimerComponent.Instance.Remove(ref self.nextWaveTimer);
            self.EnterWave();
        }

        public static void EnterWave(this LevelControl self)
        {
            var config = TDLevelConfigCategory.Instance.Get(self.ConfigId);
            var waveConfigId = config.WaveConfig[self.CurrWaveIndex];
            Log.Debug($"创建波次WaveConfigId: {waveConfigId}");
            var wave = EntityFactory.CreateWithParentAndId<WaveControl,int>(self, self.CurrWaveIndex,waveConfigId);
            wave.EnterWave();
            //todo: 加一个计时器，最大多久之后，创建下一波
        }
    }
}