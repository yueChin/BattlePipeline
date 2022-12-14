using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Kits.ClientKit.Utilities.TimelineE.AnalyseTrack
{
    /// <summary>
    /// 可播放行为 官方通常以<see cref="PlayableBehaviour"/>后缀
    /// <para><see cref="PrefabControlPlayable"/>,<seealso cref="TimeControlPlayable"/></para>
    /// </summary>
    [Serializable]
    public class AnalysePlayableBehaviour : PlayableBehaviour
    {
        public string UUID = Guid.NewGuid().ToString();
        public Color Color = new Color(0.02f, 0.58f, 0.30f, 1);
        public bool LogCreatePlayable = true;
        public bool LogClipOnBehaviourPause = true;
        public bool LogClipOnBehaviourPlay = true;
        public bool LogClipOnGraphStart = false;
        public bool LogClipDetail = false;

        public override void OnBehaviourPause(Playable playable, FrameData info)
        {
            if (LogClipOnBehaviourPause)
            {
                Debug.Log($"ClipBehaviour 触发 {nameof(AnalysePlayableBehaviour)}.{nameof(OnBehaviourPause)}。\n" +
                $"UUID:{UUID}");
            }

            base.OnBehaviourPause(playable, info);
        }

        public override void OnBehaviourPlay(Playable playable, FrameData info)
        {
            if (LogClipOnBehaviourPlay)
            {
                Debug.Log($"ClipBehaviour 触发 {nameof(AnalysePlayableBehaviour)}.{nameof(OnBehaviourPlay)}。\n" +
                $"UUID:{UUID}");
            }

            base.OnBehaviourPlay(playable, info);
        }

        public override void OnGraphStart(Playable playable)
        {
            if (LogClipOnGraphStart)
            {
                Debug.Log($"ClipBehaviour 触发 {nameof(AnalysePlayableBehaviour)}.{nameof(OnGraphStart)}。\n" +
                $"UUID:{UUID}");
            }
            base.OnGraphStart(playable);
        }

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            if (LogClipDetail)
            {
                Debug.Log($"Clip ProcessFrame Duration: {playable.GetDuration()} \n frameId {info.frameId} evaluationType {info.evaluationType}" +
                    $" deltaTime {info.deltaTime}  {info} " +
                    $"  playable {playable.GetTime()} frame {(int)(playable.GetTime() * 60)}");
            }
            base.ProcessFrame(playable, info, playerData);
        }
    }
}
