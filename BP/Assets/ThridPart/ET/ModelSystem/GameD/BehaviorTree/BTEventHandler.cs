using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET.EventIdType;

namespace ET
{
    [Event]
    public class BTEventHandler : AEvent<EventIdType.ExcuteBT>
    {
        protected override async ETTask Run(ExcuteBT data)
        {
            BTHelper.Execute(data.BtSwitch, data.entity);
            await ETTask.CompletedTask;
        }
    }
}
