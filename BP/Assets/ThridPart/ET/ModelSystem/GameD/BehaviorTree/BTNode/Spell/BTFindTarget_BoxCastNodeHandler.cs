using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    public class BTFindTarget_BoxCastNodeHandler : ANodeHandler<BTFindTarget_BoxCastNode>
    {
        public override async ETTask<bool> Run(BTFindTarget_BoxCastNode node, BTEnv env)
        {
            var caster = env.Get<Unit>(node.Caster);
            var target = env.Get<Unit>(node.Target);
            var targetCamp = node.FindFriend? caster.GetCamp() : caster.GetEnemyCamp();
            if (!caster.Domain.GetComponent<UnitComponent>().CampUnits.TryGetValue(targetCamp,out var campUnits))
            {
                return false;
            }
          
            
            var dir = node.Forward? target.Forward : -target.Forward;

            var center = target.Position + dir * node.Length / 2;


          //  var drawMatrix = Matrix4x4.TRS(center, target.Rotation, new Vector3(node.Width , 1, node.Length));
#if UNITY_EDITOR
            if (Game.Options.DebugBattle > 0)
            {
                var debugGo = GameObject.CreatePrimitive(PrimitiveType.Cube);
                debugGo.transform.position = center;
                debugGo.transform.rotation = target.Rotation;
                debugGo.transform.localScale = new Vector3(node.Width, 1, node.Length);
                GameObject.Destroy(debugGo, 2);
            }
#endif 
            
            var allHits = Physics.OverlapBox(center, new Vector3(node.Width / 2, 0.5f, node.Length / 2), target.Rotation, BattleHelper.GetUnitLayerMask());

            if (allHits == null|| allHits.Length == 0)
                return false;

            SortedDictionary<float, long> Dis2UnitId = new SortedDictionary<float, long>();
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

                Dis2UnitId[(campUnit.Position - target.Position).sqrMagnitude] = campUnit.Id;
            }

            if (Dis2UnitId.Count == 0)
                return false;
            List<long> rets = new List<long>();
            foreach (var v in Dis2UnitId)
            {
                rets.Add(v.Value);
                if (node.FindNum > 0 && rets.Count >= node.FindNum)
                {
                    break;
                }
            }

            await ETTask.CompletedTask;
            env.Add(node.Results,rets);
            return true;
        }
    }
}