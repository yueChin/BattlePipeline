using System.Collections.Generic;
using UnityEngine;

namespace ET
{

    public class WaveControlAwakeSystem : AwakeSystem<WaveControl,int>
    {
        public override void Awake(WaveControl self,int configId)
        {
            self.ConfigId = configId;
        }
    }

    public class WaveControlDestroySystem : DestroySystem<WaveControl>
    {
        public override void Destroy(WaveControl self)
        {
            foreach (var v in self.Timers)
            {
                TimerComponent.Instance.Remove(v);
            }
            self.Timers.Clear();
        }
    }

    public static class WaveControlEx
    {
        public static void EnterWave(this WaveControl self)
        {
            var waveConfig = WaveConfigCategory.Instance.Get(self.ConfigId);
            for (int i = 0; i < waveConfig.Timer.Length; i++)
            {
                Log.Debug($"创建Node  {i} Length: {waveConfig.Timer.Length}");
                var nodeIndex = i;
                var timer = TimerComponent.Instance.NewOnceTimer(TimeHelper.ServerNow() + waveConfig.Timer[nodeIndex],
                    () => self.CreateNode(nodeIndex));
                self.Timers.Add(timer);
            }

        }
        
        // 实际出怪
        public static void CreateNode(this WaveControl self, int nodeIndex)
        {
            Log.Debug($"创建Node  {nodeIndex}");
            var waveConfig = WaveConfigCategory.Instance.Get(self.ConfigId);
            var nodeCondig = WaveNodeConfigCategory.Instance.Get(waveConfig.Nodes[nodeIndex]);
            var sceneObj = SceneObjManagerComponent.Instance.Get(self.DomainScene(), waveConfig.Pos[nodeIndex]);
            for (int i = 0; i < nodeCondig.Num; i++)
            {
                var timer = TimerComponent.Instance.NewOnceTimer(TimeHelper.ServerNow() + nodeCondig.Interval,
                    () => self.CreateMonster(nodeCondig.UnitConfigId,waveConfig.Level,sceneObj));    //todo: 根据实际配置，在对应的位置刷怪
                
                self.Timers.Add(timer);
            }
        }

        public static void CreateMonster(this WaveControl self, int configId,int level,SceneObj obj)
        {
            Log.Debug($"创建怪物{configId}");
            //todo: 如果当前场景里的怪很多，那就延迟3秒创建，生成新的timer
            UnitFactory.CreateMonster(self.DomainScene(), configId, level, obj.Pos, obj.Rot).Coroutine();
        }
    }
}