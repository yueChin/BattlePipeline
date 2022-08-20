using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ET
{
    public static class BattleHelper
    {
        
        public static bool IsFriend(Unit caster, Unit target)
        {
            if (caster == target)
            {
                return true;
            }

            var casterCamp = caster.GetComponent<NumericComponent>().GetAsInt(NumericType.Camp);
            var targetCamp = target.GetComponent<NumericComponent>().GetAsInt(NumericType.Camp);
            if (casterCamp == 0 || targetCamp == 0)
                return true;
            if (casterCamp != targetCamp)
                return false;
            
            return true;
        }

        public static int GetCamp(this Unit unit)
        {
            return unit.GetComponent<NumericComponent>().GetAsInt(NumericType.Camp);
        }

        public static int GetEnemyCamp(this Unit unit)
        {
            var selfCamp = unit.GetCamp();
            return -selfCamp;
        }

        public static LayerMask GetUnitLayerMask()
        {
            return LayerMask.GetMask("Unit");
        }
    }
}
