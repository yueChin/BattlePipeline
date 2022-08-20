using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    [Serializable]
    public abstract class Node : Object
    {
        public long Id;

        public string Description;
        
        public List<Node> Children = new List<Node>();

        public void AddChild(Node child)
        {
            this.Children.Add(child);
        }

        public Node()
        {
            this.Id = IdGenerator.Instance.GenerateId(0);
        }

        //public abstract ETTask<bool> Run(BTEnv env);

        //public async ETTask<bool> Execute(BTEnv env)
        //{
        //    env.Get<BTPath>(BTEnvKey.BTPath).RunPath.Add(Id);
        //    return await Run(env);
        //}

    }
}