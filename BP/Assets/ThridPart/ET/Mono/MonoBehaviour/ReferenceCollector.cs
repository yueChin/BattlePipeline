using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
//Object并非C#基础中的Object，而是 UnityEngine.Object
using Object = UnityEngine.Object;
#if UNITY_EDITOR
using UnityEditor;

#endif

//使其能在Inspector面板显示，并且可以被赋予相应值
[Serializable]
public class ReferenceCollectorData
{
	[LabelText("")]
	[HorizontalGroup("1",width:80)]
	public string key;
	[HorizontalGroup("1",LabelWidth = 30)]
	[LabelText("Go:")]
	[OnValueChanged("OnChange")]
    //Object并非C#基础中的Object，而是 UnityEngine.Object
    public Object gameObject;

    void OnChange()
    {
	    if (this.gameObject == null)
		    return;
	    if (string.IsNullOrEmpty(this.key))
		    this.key = this.gameObject.name;
    }
}
//继承IComparer对比器，Ordinal会使用序号排序规则比较字符串，因为是byte级别的比较，所以准确性和性能都不错
public class ReferenceCollectorDataComparer: IComparer<ReferenceCollectorData>
{
	public int Compare(ReferenceCollectorData x, ReferenceCollectorData y)
	{
		return string.Compare(x.key, y.key, StringComparison.Ordinal);
	}
}

//继承ISerializationCallbackReceiver后会增加OnAfterDeserialize和OnBeforeSerialize两个回调函数，如果有需要可以在对需要序列化的东西进行操作
//ET在这里主要是在OnAfterDeserialize回调函数中将data中存储的ReferenceCollectorData转换为dict中的Object，方便之后的使用
//注意UNITY_EDITOR宏定义，在编译以后，部分编辑器相关函数并不存在
public class ReferenceCollector: MonoBehaviour, ISerializationCallbackReceiver
{
    //用于序列化的List
	public List<ReferenceCollectorData> data = new List<ReferenceCollectorData>();
	[HideInInspector]
	//Object并非C#基础中的Object，而是 UnityEngine.Object
    public readonly Dictionary<string, Object> dict = new Dictionary<string, Object>();
    
    //使用泛型返回对应key的gameobject
	public T Get<T>(string key) where T : class
	{
		Object dictGo;
		if (!dict.TryGetValue(key, out dictGo))
		{
			return null;
		}
		return dictGo as T;
	}

	public Object GetObject(string key)
	{
		Object dictGo;
		if (!dict.TryGetValue(key, out dictGo))
		{
			return null;
		}
		return dictGo;
	}

	public void OnBeforeSerialize()
	{
	}
    //在反序列化后运行
	public void OnAfterDeserialize()
	{
		dict.Clear();
		foreach (ReferenceCollectorData referenceCollectorData in data)
		{
			if (!dict.ContainsKey(referenceCollectorData.key))
			{
				dict.Add(referenceCollectorData.key, referenceCollectorData.gameObject);
			}
		}
	}
}
