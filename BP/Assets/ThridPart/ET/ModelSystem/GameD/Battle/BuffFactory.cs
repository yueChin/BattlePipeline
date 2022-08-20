using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public static class BuffFactory
    {
        public static Buff Create(Unit caster, Unit target, int configId)
        {
            var buffCom = target.GetComponent<BuffComponent>();
            var buff = EntityFactory.CreateWithParent<Buff>(buffCom);
            buff.BuffConfigId = configId;
            buff.casterId = caster.Id;
            buff.ownerId = target.Id;
            return buff;
        }

        public static Buff CreateAndAdd(Unit caster, Unit target, int configId)
        {
            var buffCom = target.GetComponent<BuffComponent>();
            var buff = EntityFactory.CreateWithParent<Buff>(buffCom);
            buff.BuffConfigId = configId;
            buff.casterId = caster.Id;
            buff.ownerId = target.Id;
            buffCom.Add(buff);
            return buff;
        }
        
    }
}
