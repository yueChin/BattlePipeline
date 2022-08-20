using System.Runtime.CompilerServices;

namespace ET
{
    public static class AIHatredComponentEx
    {
        public static Hatred GetMaxHatred(this AIHatredComponent self)
        {
            int max = -1;
            Hatred target = null;
            // 拥有仇恨值的单位不会很多，加上访问频率低，就不需要一个专门排序的容器了
            foreach (var v in self.Children)
            {
                var ha = v.Value as Hatred;
                if(ha == null)
                    continue;
                if (ha.Value > max)
                {
                    max = ha.Value;
                    target = ha;
                }
            }

            return target;
        }

        public static Hatred Get(this AIHatredComponent self, long id)
        {
            return self.GetChild<Hatred>(id);
        }

        public static void Remove(this AIHatredComponent self, long id)
        {
            var ha = self.Get(id);
            if (ha == null)
                return;
            ha.Dispose();
        }

        public static void SetHatred(this AIHatredComponent self, long id, int value)
        {
            var ha = self.Get(id);
            if (ha == null)
                ha = EntityFactory.CreateWithParentAndId<Hatred>(self, id);
            ha.Value = value;
        }
        
    }
}