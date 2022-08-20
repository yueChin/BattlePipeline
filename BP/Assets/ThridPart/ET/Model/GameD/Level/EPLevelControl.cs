using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    public class EPLevelControl : Entity
    {
        public List<Vector3> Path = new List<Vector3>();
        public int Index;
        public int ConfigId { get; set; }

        public Unit Car;
    }
}