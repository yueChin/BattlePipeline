using ET.EventIdType;
using UnityEngine;

namespace ET
{
    public class ShowCreateDamageResultEvent : AEvent<EventIdType.DamageResult>
    {
        protected override async ETTask Run(DamageResult a)
        {
            var ui = await a.Target.Domain.GetComponent<UIComponent>().CreateOrGet(UIType.UIBattleHud);
            var text = $"-{a.damage}";

            if (a.Type.HasFlag(DamageResultType.Dodge))
            {
                text = $"{text} (闪避)";
            }
            
            if (a.Type.HasFlag(DamageResultType.Immune))
            {
                text = $"{text} (免疫)";
            }
            
            if (a.Type.HasFlag(DamageResultType.Block))
            {
                text = $"{text} (格挡)";
            }
            
            if (a.Type.HasFlag(DamageResultType.Critical))
            {
                text = $"{text} (暴击！)";
            }
            
            if (a.Type.HasFlag(DamageResultType.SuperCritical))
            {
                text = $"{text} (暴击！!)";
            }

           // ui.GetComponent<UIBattleHudViewComponent>().Adaptor.ShowTips(a.Target,text,Color.red);
        }
    }
}