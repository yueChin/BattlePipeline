﻿using System;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace ET
{
	public class Entry : IEntry
	{
		public void Start()
		{
			try
			{
				string[] assemblyNames = { "Unity.Model.dll", "Unity.ModelSystem.dll", "Unity.View.dll", "Unity.ViewSystem.dll" };
				
				foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
				{
					string assemblyName = $"{assembly.GetName().Name}.dll";
					if (!assemblyNames.Contains(assemblyName))
					{
						continue;
					}
					Game.EventSystem.Add(assembly);
				}
				
				ProtobufHelper.Init();
				
				Game.Options = new Options();
				
				 Game.EventSystem.Run(new EventIdType.AppStart()).Coroutine();
			}
			catch (Exception e)
			{
				Log.Error(e);
			}
		}

		public void Update()
		{
			ThreadSynchronizationContext.Instance.Update();
			Game.EventSystem.Update();
		}

		public void LateUpdate()
		{
			Game.EventSystem.LateUpdate();
		}

		public void OnApplicationQuit()
		{
			Game.Close();
		}
	}
}