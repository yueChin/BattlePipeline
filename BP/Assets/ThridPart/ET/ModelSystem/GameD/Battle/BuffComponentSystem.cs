using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [ObjectSystem]
    public class BuffComponentAwakeSystem : AwakeSystem<BuffComponent>
    {
        public override void Awake(BuffComponent self)
        {

        }
    }

    [ObjectSystem]
    public class BuffComponentDestorySystem : DestroySystem<BuffComponent>
    {
        public override void Destroy(BuffComponent self)
        {
            foreach (var v in self.Id2Buffs.Values.ToList())
            {
                self.Remove(v.Id);
            }

            self.Id2Buffs.Clear();
            self.ConfigId2Buffs.Clear();
            self.Type2Buffs.Clear();
        }
    }


    public static class BuffComponentEx
    {
        public static int Add(this BuffComponent self, Buff buff,int layer = 1)
        {
            //先判断免疫
            var buffTypeConfig = BuffTypeConfigCategory.Instance.Get(buff.BuffConfig.BuffType);
            if (buffTypeConfig.TypeImmune != null && buffTypeConfig.TypeImmune.Length>0)
            {
                foreach (var v in buffTypeConfig.TypeImmune)
                {
                    if (self.Type2Buffs.TryGetValue(v, out var buffs) && buffs.Count > 0)
                    {
                        //因为免疫,所以加不上 todo: 返回对应的错误码
                        return 1;
                    }
                }
            }

            var oldBuff = self.GetOneByConfigId(buff.BuffConfigId);
            if (oldBuff != null)
            {
                switch (buff.BuffConfig.RepeatAdd)
                {
                    case 0:
                        break;
                    case 1:
                        self.Remove(oldBuff.Id);
                        break;
                    case 2:
                        layer = oldBuff.stack + 1;
                        self.Remove(oldBuff.Id);
                        break;
                    case 3:
                        return 0;
                }
            }
            self.Id2Buffs.Add(buff.Id, buff);

            if (!self.ConfigId2Buffs.ContainsKey(buff.BuffConfigId))
                self.ConfigId2Buffs.Add(buff.BuffConfigId, new HashSet<Buff>());
            self.ConfigId2Buffs[buff.BuffConfigId].Add(buff);
            
            if (!self.Type2Buffs.ContainsKey(buff.BuffConfig.BuffType))
                self.Type2Buffs.Add(buff.BuffConfig.BuffType, new HashSet<Buff>());
            self.Type2Buffs[buff.BuffConfig.BuffType].Add(buff);

            if (buff.BuffConfig.BuffRemoveCond != null && buff.BuffConfig.BuffRemoveCond.Length > 0)
            {
                foreach (var v in buff.BuffConfig.BuffRemoveCond)
                {
                    if (!self.RemoveCond2Buffs.ContainsKey(v))
                    {
                        self.RemoveCond2Buffs[v] = new HashSet<Buff>();
                    }

                    self.RemoveCond2Buffs[v].Add(buff);
                }
            }

            buff.Add(layer);
            
            // 判断驱散
            if (buffTypeConfig.TypeDispelled != null && buffTypeConfig.TypeDispelled.Length>0)
            {
                foreach (var v in buffTypeConfig.TypeDispelled)
                {
                    self.RemoveByType((BuffType) v);
                }
            }
            
            return 0;
        }
        public static void Remove(this BuffComponent self, long buffId)
        {
            if (!self.Id2Buffs.TryGetValue(buffId, out var buff))
            {
                return;
            }
            self.ConfigId2Buffs[buff.BuffConfigId].Remove(buff);
            self.Type2Buffs[buff.BuffConfig.BuffType].Remove(buff);
            if (buff.BuffConfig.BuffRemoveCond != null && buff.BuffConfig.BuffRemoveCond.Length > 0)
            {
                foreach (var v in buff.BuffConfig.BuffRemoveCond)
                {
                    self.RemoveCond2Buffs[v].Remove(buff);
                }
            }
            self.Id2Buffs.Remove(buff.Id);
            buff.Remove();
            buff.Dispose();
        }

        public static void TimeOut(this BuffComponent self, long buffId)
        {
            if (!self.Id2Buffs.TryGetValue(buffId, out var buff))
            {
                return;
            }
            self.ConfigId2Buffs[buff.BuffConfigId].Remove(buff);
            self.Type2Buffs[buff.BuffConfig.BuffType].Remove(buff);
            if (buff.BuffConfig.BuffRemoveCond != null && buff.BuffConfig.BuffRemoveCond.Length > 0)
            {
                foreach (var v in buff.BuffConfig.BuffRemoveCond)
                {
                    self.RemoveCond2Buffs[v].Remove(buff);
                }
            }
            self.Id2Buffs.Remove(buff.Id);
            buff.TimeOut();
            buff.Dispose();     
        }

        public static bool Contains(this BuffComponent self, long buffId)
        {
            return self.Id2Buffs.TryGetValue(buffId, out var buff);
        }

        public static bool TryGet(this BuffComponent self, long buffId, out Buff buff)
        {
            return self.Id2Buffs.TryGetValue(buffId, out buff);
        }

        public static Buff GetOneByConfigId(this BuffComponent self, int configId)
        {
            if (!self.ConfigId2Buffs.TryGetValue(configId, out var buffs)) return null;
            if (buffs.Count == 0) return null;
            return buffs.First();
        }

        public static void RemoveOneByConfigId(this BuffComponent self, int configId)
        {
            if (!self.ConfigId2Buffs.TryGetValue(configId, out var buffs)) return;
            if (buffs.Count == 0) return;
            self.Remove(buffs.First().Id);
        }

        public static HashSet<Buff> GetAllByConfigId(this BuffComponent self, int configId)
        {
            if (!self.ConfigId2Buffs.TryGetValue(configId, out var buffs)) return null;
            return buffs;
        }

        public static bool IsExist(this BuffComponent self, BuffIDConst configId)
        {
            if (!self.ConfigId2Buffs.TryGetValue((int)configId, out var buffs)) return false;
            if (buffs.Count == 0) return false;
            return true;
        }

        public static HashSet<Buff> GetAllByType(this BuffComponent self, BuffType buffType)       
        {
            if (!self.Type2Buffs.TryGetValue((int)buffType, out var buffs)) return null;
            return buffs;
        }

        public static Buff GetOneByFlag(this BuffComponent self, BuffTypeFlag flag)
        {
            if (!BuffTypeConfigCategory.Instance.Flag2Types.TryGetValue((int) flag, out var allTypes)) return null;
            foreach (var v in allTypes)
            {
                var buffs = self.GetAllByType((BuffType)v);
                if(buffs == null) continue;
                return buffs.First();
            }

            return null;
        }

        public static void GetAllByFlag(this BuffComponent self, BuffTypeFlag flag, List<Buff> Buffs)
        {
            if (flag == BuffTypeFlag.None)
            {
                throw new Exception("逻辑错误 ");
            }
            if (!BuffTypeConfigCategory.Instance.Flag2Types.TryGetValue((int) flag, out var allTypes)) return;
            foreach (var v in allTypes)
            {
                var buffs = self.GetAllByType((BuffType)v);
                if(buffs == null) continue;
                Buffs.AddRange(buffs);
            }
        }

        public static void RemoveByCond(this BuffComponent self, BuffRemoveCondType condType)
        {
            if (!self.RemoveCond2Buffs.TryGetValue((int) condType, out var set)) return;
            using (var list =ListComponent<Buff>.Create())
            {
                list.List.AddRange(set);
                foreach (var v in list.List)
                {
                    self.Remove(v.Id);
                }   
            }
        }

        public static void RemoveByType(this BuffComponent self, BuffType buffType)
        {
            if (!self.Type2Buffs.TryGetValue((int) buffType, out var set)) return;
            using (var list =ListComponent<Buff>.Create())
            {
                list.List.AddRange(set);
                foreach (var v in list.List)
                {
                    self.Remove(v.Id);
                }   
            }
        }

    }
}
