using System;
using System.Collections.Generic;

namespace ET
{
	public class BTEnv: Entity
	{
		public Dictionary<string, object> Values
		{
			get
			{
				return values;
			}
		}

		public readonly Dictionary<string, object> values = new Dictionary<string, object>();

		public readonly HashSet<Entity> disposers = new HashSet<Entity>();

		public override void Dispose()
		{
			if (this.IsDisposed)
			{
				return;
			}
			
			base.Dispose();

			this.values.Clear();

			foreach (var v in this.disposers)
			{
				v.Dispose();
			}
			this.disposers.Clear();
		}

		public void CopyTo(BTEnv env)
		{
			foreach (KeyValuePair<string, object> keyValuePair in this.values)
			{
				env.values.Add(keyValuePair.Key, keyValuePair.Value);
			}

			foreach (Entity disposer in this.disposers)
			{
				env.disposers.Add(disposer);
			}
		}

		public T Get<T>(string key)
		{
			if (!this.values.ContainsKey(key))
			{
				return default(T);
			}
			
			object value = values[key];
			try
			{
				if (typeof (T).IsClass)
				{
					return (T) value;
				}

				IValue<T> iValue = (IValue<T>) value;
				return iValue.Value;
			}
			catch (InvalidCastException e)
			{
				throw new Exception($"不能把{value.GetType()}转换为{typeof (T)}", e);
			}
 		}
		
		public bool ContainKey(string key)
		{
			return this.values.ContainsKey(key);
		}

		public void Add<T>(string key, T value)
		{
			var type = typeof(T);
			if (type.IsClass)
			{
				this.values[key] = value;
				return;
			}
			
			ValueTypeWrap<T> wrap = EntityFactory.CreateWithParent<ValueTypeWrap<T>>(this);
			wrap.Value = value;
			this.values[key] = wrap;
			this.disposers.Add(wrap);
		}
	}
}