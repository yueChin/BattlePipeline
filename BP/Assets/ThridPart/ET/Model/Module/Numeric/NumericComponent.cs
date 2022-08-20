using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using Unity.Collections;
using UnityEngine;

namespace ET
{
	public class NumericComponent: Entity
#if SERVER
		,IUnitDB
#endif
	{
		[BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
		public Dictionary<int, long> NumericDic = new Dictionary<int, long>();
		
		public float GetAsFloat(NumericType numericType)
		{
			return (float)GetByKey((int)numericType) / 10000;
		}
		
		public float GetAsFloat(int numericType)
		{
			return (float)GetByKey(numericType) / 10000;
		}

		public int GetAsInt(NumericType numericType)
		{
			return (int)GetByKey((int)numericType);
		}
		
		public long GetAsLong(NumericType numericType)
		{
			return GetByKey((int)numericType);
		}
		
		public int GetAsInt(int numericType)
		{
			return (int)GetByKey(numericType);
		}
		
		public long GetAsLong(int numericType)
		{
			return GetByKey(numericType);
		}

		public void Set(NumericType nt, float value)
		{
			this[nt] = (int) (value * 10000);
		}

		public void Set(NumericType nt, int value)
		{
			this[nt] = value;
		}
		
		public void Set(NumericType nt, long value)
		{
			this[nt] = value;
		}

		public long this[NumericType numericType]
		{
			get
			{
				return this.GetByKey((int) numericType);
			}
			set
			{
				long v = this.GetByKey((int) numericType);
				if (v == value)
				{
					return;
				}

				NumericDic[(int)numericType] = value;

				Game.EventSystem.Run(new EventIdType.NumbericChange()
				{
					Unit = this.GetParent<Unit>(), 
					NumericType = numericType,
					Old = v,
					New = value
				}).Coroutine();
				
				Update(numericType);
			}
		}

		private long GetByKey(int key)
		{
			long value = 0;
			this.NumericDic.TryGetValue(key, out value);
			return value;
		}

		public void Update(NumericType numericType,bool withEvent = true)
		{
			if (numericType < NumericType.Max)
			{
				return;
			}
			int final = (int) numericType / 10;
			int bas = final * 10 + 1; 
			int add = final * 10 + 2;
			int pct = final * 10 + 3;
			int finalAdd = final * 10 + 4;
			int finalPct = final * 10 + 5;

			// 一个数值可能会多种情况影响，比如速度,加个buff可能增加速度绝对值100，也有些buff增加10%速度，所以一个值可以由5个值进行控制其最终结果
			// final = (((base + add) * (100 + pct) / 100) + finalAdd) * (100 + finalPct) / 100;
			this.NumericDic.TryGetValue(final,out var old);

			var baseV = this.GetByKey(bas) + this.GetByKey(add);
			var base_pct = baseV * (10000 + this.GetAsLong(pct)) / 10000;
			var finalV = base_pct + this.GetByKey(finalAdd);
			var result = finalV * (10000 + this.GetAsLong(finalPct)) / 10000;
			
			this.NumericDic[final] = result;
			if (!withEvent)
				return;
			Game.EventSystem.Run(new EventIdType.NumbericChange()
			{
				Unit = this.GetParent<Unit>(), 
				NumericType = (NumericType) final,
				Old = old,
				New = result
			}).Coroutine();
		}

		public void Change(NumericType type, long value)
		{
			var old = this.GetAsLong(type);
			var newValue = old + value;
			//todo: 后续走配表
			switch (type)
			{
				case NumericType.HP:
				{
					if (newValue < 0)
						newValue = 0;
					var maxValue = this.GetAsLong(NumericType.MaxHP);
					if (newValue > maxValue)
						newValue = maxValue;
				}
					break;
				case NumericType.MP:
				{
					if (newValue < 0)
						newValue = 0;
					var maxValue = this.GetAsLong(NumericType.MaxMP);
					if (newValue > maxValue)
						newValue = maxValue;
				}
					break;
				case NumericType.Shield:
				{
					if (newValue < 0)
						newValue = 0;
					var maxValue = this.GetAsLong(NumericType.MaxShield);
					if (newValue > maxValue)
						newValue = maxValue;
				}
					break;

			}
			this.Set(type, old + value);
		}

		public void SetWithoutEvent(NumericType type, long value)
		{
			this.NumericDic[(int) type] = value;
			Update(type);
		}
	}
}