using System;

namespace ET
{
    public interface INodeHandler
    {
        ETTask<bool> Execute(Node node, BTEnv env);
        Type NodeType { get; }
    }
}