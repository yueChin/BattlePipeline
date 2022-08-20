using System;
using System.Runtime.InteropServices;

namespace ET
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct IdStruct
    {
        public static byte Head = 1; // 1bit
        public uint Time;    // 30bit
        public int Process;  // 17bit
        public ushort Value; // 16bit

        //为了防止和玩家的id重复,最高为固定为0
        public long ToLong()
        {
            ulong result = 0;
            result |= this.Value;
            result |= (ulong) this.Process << 16;
            result |= (ulong) this.Time << 33;
            result |= (ulong) Head << 63;
            return (long) result;
        }

        public IdStruct(uint time, int process, ushort value)
        {
            this.Process = process;
            this.Time = time;
            this.Value = value;
        }

        public override string ToString()
        {
            return $"process: {this.Process}, time: {this.Time}, value: {this.Value}";
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct InstanceIdStruct
    {
        public uint Time;   // 当年开始的tick 28bit
        public int Process; // 18bit
        public uint Value;  // 18bit

        public long ToLong()
        {
            ulong result = 0;
            result |= this.Value;
            result |= (ulong)this.Process << 18;
            result |= (ulong) this.Time << 36;
            return (long) result;
        }

        public InstanceIdStruct(long id)
        {
            ulong result = (ulong) id;
            this.Value = (uint)(result & IdGenerator.Mask18bit);
            result >>= 18;
            this.Process = (int)(result & IdGenerator.Mask18bit);
            result >>= 18;
            this.Time = (uint)result;
        }

        public InstanceIdStruct(uint time, int process, uint value)
        {
            this.Time = time;
            this.Process = process;
            this.Value = value;
        }
        
        // 给SceneId使用
        public InstanceIdStruct(int process, uint value)
        {
            this.Time = 0;
            this.Process = process;
            this.Value = value;
        }

        public override string ToString()
        {
            return $"process: {this.Process}, value: {this.Value} time: {this.Time}";
        }
    }
    
    // UnitId每个区只在1个进程里产生
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct UnitIdStruct
    {
        public int Zone;      // 21bit 10W个区
        public uint Time;        // 32 bit 当年开始的时间戳 ， 可以管100年
        public int Value;     // 10bit 每个区每秒最多创建1024个玩家角色

        // 玩家Id最高位永远是0，普通id最高位永远是1，防止一致
        public long ToLong()
        {
            ulong result = 0;
            result |= (ulong) this.Zone << 42;
            result |= (ulong) this.Time << 10;
            result |= (uint) this.Value;
            return (long) result;
        }

        public UnitIdStruct(int zone,uint time, int value)
        {
            this.Value = value;
            this.Zone = zone;
            this.Time = time;
        }
        
        public UnitIdStruct(long id)
        {
            ulong result = (ulong) id;
            this.Value = (int)(result & 0x3ff);
            result >>= 10;
            this.Time =  (uint)(result & uint.MaxValue);
            result >>= 32;
            this.Zone = (int) result;
        }
                        
        public override string ToString()
        {
            return $"Zone: {this.Zone},Time: {this.Time} value: {this.Value}";
        }
        
        public static int GetUnitZone(long unitId)
        {
            var v = (int) (unitId >> 42); // 取出22bit
            return v;
        }
    }

    public class IdGenerator: IDisposable
    {
        public const int Mask18bit = 0x03ffff;
        public static IdGenerator Instance = new IdGenerator();

        public const int MaxZone = 0x1fffff;
        
        private long epoch2020;
        private ushort value;
        private uint lastIdTime;

        
        private long epochThisYear;
        private uint instanceIdValue;
        private uint lastInstanceIdTime;

        private int unitIdValue;
        public uint lastUnitIdTime;
        
        public IdGenerator()
        {
            long epoch1970tick = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks / 10000;
            this.epoch2020 = new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks / 10000 - epoch1970tick;
            this.epochThisYear = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks / 10000 - epoch1970tick;
            
            this.lastInstanceIdTime = TimeSinceThisYear();
            if (this.lastInstanceIdTime <= 0)
            {
                Log.Warning($"lastInstanceIdTime less than 0: {this.lastInstanceIdTime}");
                this.lastInstanceIdTime = 1;
            }
            this.lastIdTime = TimeSince2020();
            if (this.lastIdTime <= 0)
            {
                Log.Warning($"lastIdTime less than 0: {this.lastIdTime}");
                this.lastIdTime = 1;
            }
        }

        public void Dispose()
        {
            this.epoch2020 = 0;
            this.epochThisYear = 0;
            this.value = 0;
        }

        public uint TimeSince2020()
        {
            uint a = (uint)((Game.TimeInfo.FrameTime - this.epoch2020) / 1000);
            return a;
        }
        
        private uint TimeSinceThisYear()
        {
            uint a = (uint)((Game.TimeInfo.FrameTime - this.epochThisYear) / 1000);
            return a;
        }
        
        public long GenerateInstanceId()
        {
            uint time = TimeSinceThisYear();

            if (time > this.lastInstanceIdTime)
            {
                this.lastInstanceIdTime = time;
                this.instanceIdValue = 0;
            }
            else
            {
                ++this.instanceIdValue;
                
                if (this.instanceIdValue > IdGenerator.Mask18bit - 1) // 18bit
                {
                    ++this.lastInstanceIdTime; // 借用下一秒
                    this.instanceIdValue = 0;
#if NOT_UNITY
                    Log.Error($"instanceid count per sec overflow: {time} {this.lastInstanceIdTime}");
#endif
                }
            }

            InstanceIdStruct instanceIdStruct = new InstanceIdStruct(this.lastInstanceIdTime, Game.Options.Process, this.instanceIdValue);
            return instanceIdStruct.ToLong();
        }

        public long GenerateId()
        {
            uint time = TimeSince2020();

            if (time > this.lastIdTime)
            {
                this.lastIdTime = time;
                this.value = 0;
            }
            else
            {
                ++this.value;
                
                if (value > ushort.MaxValue - 1)
                {
                    this.value = 0;
                    ++this.lastIdTime; // 借用下一秒
                    Log.Error($"id count per sec overflow: {time} {this.lastIdTime}");
                }
            }

            var process = 0;
            if (Game.Options != null)
            {
                process = Game.Options.Process;
            }

            IdStruct idStruct = new IdStruct(this.lastIdTime,process, value);
            return idStruct.ToLong();
        }
        
        public long GenerateId(int process)
        {
            uint time = TimeSince2020();

            if (time > this.lastIdTime)
            {
                this.lastIdTime = time;
                this.value = 0;
            }
            else
            {
                ++this.value;
                
                if (value > ushort.MaxValue - 1)
                {
                    this.value = 0;
                    ++this.lastIdTime; // 借用下一秒
                    Log.Error($"id count per sec overflow: {time} {this.lastIdTime}");
                }
            }
            
            IdStruct idStruct = new IdStruct(this.lastIdTime, process, value);
            return idStruct.ToLong();
        }

        public long GenerateUnitId(int zone)
        {
            if (zone >= MaxZone)
            {
                throw new Exception($"zone > MaxZone: {zone}");
            }
            uint time = TimeSince2020();

            if (time > this.lastUnitIdTime)
            {
                this.lastUnitIdTime = time;
                this.unitIdValue = 0;
            }
            else
            {
                ++this.unitIdValue;
                
                if (this.unitIdValue > 0x3ff - 1) // 10bit
                {
                    ++this.lastUnitIdTime; // 借用下一秒
#if NOT_UNITY
                    Log.Error($"UnitId count per sec overflow: {unitIdValue}");
#endif
                    this.unitIdValue = 0;
                }
            }

            UnitIdStruct unitIdStruct = new UnitIdStruct(zone, lastUnitIdTime,unitIdValue);
            return unitIdStruct.ToLong();
        }
    }
}