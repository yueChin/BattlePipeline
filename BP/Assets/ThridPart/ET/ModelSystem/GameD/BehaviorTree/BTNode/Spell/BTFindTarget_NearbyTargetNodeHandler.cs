using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    public class BTFindTarget_NearbyTargetNodeHandler : ANodeHandler<BTFindTarget_NearbyTargetNode>
    {
        public override async ETTask<bool> Run(BTFindTarget_NearbyTargetNode node, BTEnv env)
        {
            var caster = env.Get<Unit>(node.Caster);
            var target = env.Get<Unit>(node.Target);
            var targetCamp = node.FindFriend? caster.GetCamp() : caster.GetEnemyCamp();
            if (!caster.Domain.GetComponent<UnitComponent>().CampUnits.TryGetValue(targetCamp,out var campUnits))
            {
                return false;
            }
            List<long> rets = new List<long>();

            var halfTheta = node.HalfTheta;
            var dir = node.Forward? target.Forward : -target.Forward;

#if UNITY_EDITOR
            if (Game.Options.DebugBattle > 0)
            {
                var debugGo = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                debugGo.transform.position = target.Position;
                debugGo.transform.localScale = new Vector3(node.Range, node.Range, node.Range);
                GameObject.Destroy(debugGo, 2);
            }
#endif 
            
            var allHits = Physics.OverlapSphere(target.Position, node.Range, BattleHelper.GetUnitLayerMask());

            if (allHits == null || allHits.Length == 0)
                return false;

            foreach (var v in allHits)
            {
                var entityGameObject = v.gameObject.GetComponent<EntityGameObject>();
                if (entityGameObject == null)
                    continue;
                var campUnit = entityGameObject.obj as Unit;
                if (campUnit == null)
                {
                    continue;
                }

                if (!campUnit.Config.JoinBattle)
                    continue;
                if (!campUnit.GetAlive())
                    continue;
                if (campUnit.GetCamp() != targetCamp)
                {
                //    Log.Debug("阵营不同，不考虑 "+ campUnit.GetCamp() + "  "+ v.collider.name);
                    continue;
                }

                if (halfTheta<179 && !MathHelper.IsPointInsideCircle(
                    new Sector()
                    {
                        Dir = dir.ToV2(), HalfTheta = halfTheta, Origin = target.Position.ToV2(), range = node.Range + campUnit.Config.Radius
                    }, campUnit.Position))
                {
                    continue;
                }

                rets.Add(campUnit.Id);
            }

            if (rets.Count == 0)
                return false;
            await ETTask.CompletedTask;
            env.Add(node.Results,rets);
            return true;
        }
    }
}