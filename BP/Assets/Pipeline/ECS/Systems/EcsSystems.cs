using System;
using System.Collections.Generic;
using System.Reflection;

namespace ECS
{
    /// <summary>
    /// Logical group of systems.
    /// </summary>
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public sealed class EcsSystems : IEcsStartSystem, IEcsDestroySystem, IEcsRunSystem
    {
        public readonly string Name;
        public readonly EcsWorld World;
        private readonly EcsGrowList<IEcsSystem> m_AllSystemGrowList = new EcsGrowList<IEcsSystem>(64);
        private readonly EcsGrowList<EcsSystemsRunItem> m_RunSystemGrowList = new EcsGrowList<EcsSystemsRunItem>(64);
        private readonly Dictionary<int, int> m_NamedRunSystemDict = new Dictionary<int, int>(64);
        private readonly Dictionary<Type, object> m_InjectionDict = new Dictionary<Type, object>(32);
        private bool m_Injected;
#if DEBUG
        private bool m_Initialized;
        private bool m_Destroyed;
        private readonly List<IEcsSystemsDebugListener> m_DebugListeners = new List<IEcsSystemsDebugListener>(4);

        /// <summary>
        /// Adds external event listener.
        /// </summary>
        /// <param name="listener">Event listener.</param>
        public void AddDebugListener(IEcsSystemsDebugListener listener)
        {
            if (listener == null)
            {
                throw new Exception("listener is null");
            }

            m_DebugListeners.Add(listener);
        }

        /// <summary>
        /// Removes external event listener.
        /// </summary>
        /// <param name="listener">Event listener.</param>
        public void RemoveDebugListener(IEcsSystemsDebugListener listener)
        {
            if (listener == null)
            {
                throw new Exception("listener is null");
            }

            m_DebugListeners.Remove(listener);
        }
#endif

        /// <summary>
        /// Creates new instance of EcsSystems group.
        /// </summary>
        /// <param name="world">EcsWorld instance.</param>
        /// <param name="name">Custom name for this group.</param>
        public EcsSystems(EcsWorld world, string name = null)
        {
            World = world;
            Name = name;
        }

        /// <summary>
        /// Adds new system to processing.
        /// </summary>
        /// <param name="system">System instance.</param>
        /// <param name="namedRunSystem">Optional name of system.</param>
        public EcsSystems Add(IEcsSystem system, string namedRunSystem = null)
        {
#if DEBUG
            if (system == null)
            {
                throw new Exception("System is null.");
            }

            if (m_Initialized)
            {
                throw new Exception("Cant add system after initialization.");
            }

            if (m_Destroyed)
            {
                throw new Exception("Cant touch after destroy.");
            }

            if (!string.IsNullOrEmpty(namedRunSystem) && !(system is IEcsRunSystem))
            {
                throw new Exception("Cant name non-IEcsRunSystem.");
            }
#endif
            m_AllSystemGrowList.Add(system);
            if (system is IEcsRunSystem)
            {
                if (namedRunSystem == null && system is EcsSystems ecsSystems)
                {
                    namedRunSystem = ecsSystems.Name;
                }

                if (namedRunSystem != null)
                {
#if DEBUG
                    if (m_NamedRunSystemDict.ContainsKey(namedRunSystem.GetHashCode()))
                    {
                        throw new Exception($"Cant add named system - \"{namedRunSystem}\" name already exists.");
                    }
#endif
                    m_NamedRunSystemDict[namedRunSystem.GetHashCode()] = m_RunSystemGrowList.Count;
                }

                m_RunSystemGrowList.Add(new EcsSystemsRunItem { Active = true, System = (IEcsRunSystem)system });
            }

            return this;
        }

        public int GetNamedRunSystem(string name)
        {
            return m_NamedRunSystemDict.TryGetValue(name.GetHashCode(), out int idx) ? idx : -1;
        }

        /// <summary>
        /// Sets IEcsRunSystem active state.
        /// </summary>
        /// <param name="idx">Index of system.</param>
        /// <param name="state">New state of system.</param>
        public void SetRunSystemState(int idx, bool state)
        {
#if DEBUG
            if (idx < 0 || idx >= m_RunSystemGrowList.Count)
            {
                throw new Exception("Invalid index");
            }
#endif
            m_RunSystemGrowList.Items[idx].Active = state;
        }

        /// <summary>
        /// Gets IEcsRunSystem active state.
        /// </summary>
        /// <param name="idx">Index of system.</param>
        public bool GetRunSystemState(int idx)
        {
#if DEBUG
            if (idx < 0 || idx >= m_RunSystemGrowList.Count)
            {
                throw new Exception("Invalid index");
            }
#endif
            return m_RunSystemGrowList.Items[idx].Active;
        }

        /// <summary>
        /// Get all systems. Important: Don't change collection!
        /// </summary>
        public EcsGrowList<IEcsSystem> GetAllSystems()
        {
            return m_AllSystemGrowList;
        }

        /// <summary>
        /// Gets all run systems. Important: Don't change collection!
        /// </summary>
        public EcsGrowList<EcsSystemsRunItem> GetRunSystems()
        {
            return m_RunSystemGrowList;
        }

        /// <summary>
        /// Injects instance of object type to all compatible fields of added systems.
        /// </summary>
        /// <param name="obj">Instance.</param>
        /// <param name="overridenType">Overriden type, if null - typeof(obj) will be used.</param>
        public EcsSystems Inject(object obj, Type overridenType = null)
        {
#if DEBUG
            if (m_Initialized)
            {
                throw new Exception("Cant inject after initialization.");
            }

            if (obj == null)
            {
                throw new Exception("Cant inject null instance.");
            }

            if (overridenType != null && !overridenType.IsInstanceOfType(obj))
            {
                throw new Exception("Invalid overriden type.");
            }
#endif
            if (overridenType == null)
            {
                overridenType = obj.GetType();
            }

            m_InjectionDict[overridenType] = obj;
            return this;
        }

        /// <summary>
        /// Processes injections immediately.
        /// Can be used to DI before Init() call.
        /// </summary>
        public EcsSystems ProcessInjects()
        {
#if DEBUG
            if (m_Initialized)
            {
                throw new Exception("Cant inject after initialization.");
            }

            if (m_Destroyed)
            {
                throw new Exception("Cant touch after destroy.");
            }
#endif
            if (!m_Injected)
            {
                m_Injected = true;
                for (int i = 0, iMax = m_AllSystemGrowList.Count; i < iMax; i++)
                {
                    if (m_AllSystemGrowList.Items[i] is EcsSystems nestedSystems)
                    {
                        foreach (KeyValuePair<Type, object> pair in m_InjectionDict)
                        {
                            nestedSystems.m_InjectionDict[pair.Key] = pair.Value;
                        }

                        nestedSystems.ProcessInjects();
                    }
                    else
                    {
                        m_AllSystemGrowList.Items[i].InjectDataToSystem( World, m_InjectionDict);
                    }
                }
            }

            return this;
        }

        /// <summary>
        /// Registers component type as one-frame for auto-removing at this point in execution sequence.
        /// </summary>
        public EcsSystems OneFrame<T>() where T : struct
        {
            return Add(new RemoveOneFrame<T>());
        }

        /// <summary>
        /// Closes registration for new systems, initialize all registered.
        /// </summary>
        public void Start()
        {
#if DEBUG
            if (m_Initialized)
            {
                throw new Exception("Already initialized.");
            }

            if (m_Destroyed)
            {
                throw new Exception("Cant touch after destroy.");
            }
#endif
            ProcessInjects();
            // IEcsPreInitSystem processing.
            for (int i = 0, iMax = m_AllSystemGrowList.Count; i < iMax; i++)
            {
                IEcsSystem system = m_AllSystemGrowList.Items[i];
                if (system is IEcsAwakeSystem awakeSystem)
                {
                    awakeSystem.Awake();
#if DEBUG
                    World.CheckForLeakedEntities($"{awakeSystem.GetType().Name}.PreInit()");
#endif
                }
            }

            // IEcsInitSystem processing.
            for (int i = 0, iMax = m_AllSystemGrowList.Count; i < iMax; i++)
            {
                IEcsSystem system = m_AllSystemGrowList.Items[i];
                if (system is IEcsStartSystem initSystem)
                {
                    initSystem.Start();
#if DEBUG
                    World.CheckForLeakedEntities($"{initSystem.GetType().Name}.Init()");
#endif
                }
            }
#if DEBUG
            m_Initialized = true;
#endif
        }

        /// <summary>
        /// Processes all IEcsRunSystem systems.
        /// </summary>
        public void Run()
        {
#if DEBUG
            if (!m_Initialized)
            {
                throw new Exception($"[{Name ?? "NONAME"}] EcsSystems should be initialized before.");
            }

            if (m_Destroyed)
            {
                throw new Exception("Cant touch after destroy.");
            }
#endif
            for (int i = 0, iMax = m_RunSystemGrowList.Count; i < iMax; i++)
            {
                EcsSystemsRunItem runItem = m_RunSystemGrowList.Items[i];
                if (runItem.Active)
                {
                    runItem.System.Run();
                }
#if DEBUG
                if (World.CheckForLeakedEntities(null))
                {
                    throw new Exception($"Empty entity detected, possible memory leak in {m_RunSystemGrowList.Items[i].GetType().Name}.Run ()");
                }
#endif
            }
        }

        /// <summary>
        /// Destroys registered data.
        /// </summary>
        public void Destroy()
        {
#if DEBUG
            if (m_Destroyed)
            {
                throw new Exception("Already destroyed.");
            }

            m_Destroyed = true;
#endif
            // IEcsDestroySystem processing.
            for (int i = m_AllSystemGrowList.Count - 1; i >= 0; i--)
            {
                IEcsSystem system = m_AllSystemGrowList.Items[i];
                if (system is IEcsDestroySystem destroySystem)
                {
                    destroySystem.Destroy();
#if DEBUG
                    World.CheckForLeakedEntities($"{destroySystem.GetType().Name}.Destroy ()");
#endif
                }
            }

            // IEcsPostDestroySystem processing.
            for (int i = m_AllSystemGrowList.Count - 1; i >= 0; i--)
            {
                IEcsSystem system = m_AllSystemGrowList.Items[i];
                if (system is IEcsPostDestroySystem postDestroySystem)
                {
                    postDestroySystem.PostDestroy();
#if DEBUG
                    World.CheckForLeakedEntities($"{postDestroySystem.GetType().Name}.PostDestroy ()");
#endif
                }
            }
#if DEBUG
            for (int i = 0, iMax = m_DebugListeners.Count; i < iMax; i++)
            {
                m_DebugListeners[i].OnSystemsDestroyed(this);
            }
#endif
        }


    }

    /// <summary>
    /// System for removing OneFrame component.
    /// </summary>
    /// <typeparam name="T">OneFrame component type.</typeparam>
    internal sealed class RemoveOneFrame<T> : IEcsRunSystem where T : struct
    {
        private readonly EcsFilter<T> m_OneFrames = null;

        void IEcsRunSystem.Run()
        {
            for (int idx = m_OneFrames.GetEntitiesCount() - 1; idx >= 0; idx--)
            {
                m_OneFrames.GetEntity(idx).Del<T>();
            }
        }
    }

    /// <summary>
    /// IEcsRunSystem instance with active state.
    /// </summary>
    public sealed class EcsSystemsRunItem
    {
        public bool Active;
        public IEcsRunSystem System;
    }
}