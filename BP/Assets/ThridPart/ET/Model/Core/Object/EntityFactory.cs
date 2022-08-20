using System;

namespace ET
{
    public static class EntityFactory
    {
        public static T CreateWithParent<T>(Entity parent, bool isFromPool = false) where T : Entity
        {
            Type type = typeof (T);
            T component = (T) Entity.Create(type, isFromPool);
            component.Id = IdGenerator.Instance.GenerateId();
            component.Parent = parent;

            EventSystem.Instance.Awake(component);
            return component;
        }

        public static T CreateWithParent<T, A>(Entity parent, A a, bool isFromPool = false) where T : Entity
        {
            Type type = typeof (T);
            T component = (T) Entity.Create(type, isFromPool);
            component.Id = IdGenerator.Instance.GenerateId();
            component.Parent = parent;

            EventSystem.Instance.Awake(component, a);
            return component;
        }

        public static T CreateWithParent<T, A, B>(Entity parent, A a, B b, bool isFromPool = false) where T : Entity
        {
            Type type = typeof (T);
            T component = (T) Entity.Create(type, isFromPool);
            component.Id = IdGenerator.Instance.GenerateId();
            component.Parent = parent;

            EventSystem.Instance.Awake(component, a, b);
            return component;
        }

        public static T CreateWithParent<T, A, B, C>(Entity parent, A a, B b, C c, bool isFromPool = false) where T : Entity
        {
            Type type = typeof (T);
            T component = (T) Entity.Create(type, isFromPool);
            component.Id = IdGenerator.Instance.GenerateId();
            component.Parent = parent;

            EventSystem.Instance.Awake(component, a, b, c);
            return component;
        }

        public static T CreateWithParent<T, A, B, C, D>(Entity parent, A a, B b, C c, D d, bool isFromPool = false) where T : Entity
        {
            Type type = typeof (T);
            T component = (T) Entity.Create(type, isFromPool);
            component.Id = IdGenerator.Instance.GenerateId();
            component.Parent = parent;

            EventSystem.Instance.Awake(component, a, b, c, d);
            return component;
        }

        public static T CreateWithParentAndId<T>(Entity parent, long id, bool isFromPool = false) where T : Entity
        {
            Type type = typeof (T);
            T component = (T) Entity.Create(type, isFromPool);
            component.Id = id;
            component.Parent = parent;

            EventSystem.Instance.Awake(component);
            return component;
        }

        public static T CreateWithParentAndId<T, A>(Entity parent, long id, A a, bool isFromPool = false) where T : Entity
        {
            Type type = typeof (T);
            T component = (T) Entity.Create(type, isFromPool);
            component.Id = id;
            component.Parent = parent;

            EventSystem.Instance.Awake(component, a);
            return component;
        }

        public static T CreateWithParentAndId<T, A, B>(Entity parent, long id, A a, B b, bool isFromPool = false) where T : Entity
        {
            Type type = typeof (T);
            T component = (T) Entity.Create(type, isFromPool);
            component.Id = id;
            component.Parent = parent;

            EventSystem.Instance.Awake(component, a, b);
            return component;
        }

        public static T CreateWithParentAndId<T, A, B, C>(Entity parent, long id, A a, B b, C c, bool isFromPool = false) where T : Entity
        {
            Type type = typeof (T);
            T component = (T) Entity.Create(type, isFromPool);
            component.Id = id;
            component.Parent = parent;

            EventSystem.Instance.Awake(component, a, b, c);
            return component;
        }

        public static T CreateWithParentAndId<T, A, B, C, D>(Entity parent, long id, A a, B b, C c, D d, bool isFromPool = false) where T : Entity
        {
            Type type = typeof (T);
            T component = (T) Entity.Create(type, isFromPool);
            component.Id = id;
            component.Parent = parent;

            EventSystem.Instance.Awake(component, a, b, c, d);
            return component;
        }
    }
}