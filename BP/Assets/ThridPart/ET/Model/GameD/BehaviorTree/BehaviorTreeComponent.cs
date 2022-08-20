using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET
{

	public class BehaviorTreeComponent : Entity
	{
		public static BehaviorTreeComponent Instance;
		public Dictionary<string, BehaviorTree> BehaviorTrees = new Dictionary<string, BehaviorTree>();

		public Dictionary<Type, INodeHandler> AllNodeHandlers = new Dictionary<Type, INodeHandler>();

		public IConfigLoader loader;

		public void LoadHandlers()
		{
			AllNodeHandlers.Clear();
			foreach (var v in Game.EventSystem.GetTypes(typeof(BehaviorTreeAttribute)))
			{
				INodeHandler handler = Activator.CreateInstance(v) as INodeHandler;
				AllNodeHandlers.Add(handler.NodeType, handler);
			}
		}

		public void Add(string key, BehaviorTree tree)
		{
			//Log.Debug($"BT: [{category}] [{key}]");
			BehaviorTrees[key] = tree;
		}

		public bool TryGet(string key, out BehaviorTree tree)
		{
			if (!BehaviorTrees.TryGetValue(key, out tree))
			{
				return false;
			}

			return true;
		}


		public override void Dispose()
		{
			if (IsDisposed) return;
			base.Dispose();
			BehaviorTrees.Clear();
			AllNodeHandlers.Clear();
			Instance = null;
		}
	}
}
