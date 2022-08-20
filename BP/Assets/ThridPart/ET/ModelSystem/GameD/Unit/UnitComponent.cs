using System.Collections.Generic;
using System.Linq;

namespace ET
{
	
	public class UnitComponentAwakeSystem : AwakeSystem<UnitComponent>
	{
		public override void Awake(UnitComponent self)
		{
		}
	}
	
	public class UnitComponentDestroySystem : DestroySystem<UnitComponent>
	{
		public override void Destroy(UnitComponent self)
		{
			foreach (Unit unit in self.idUnits.Values)
			{
				unit.Dispose();
			}

			self.idUnits.Clear();
		}
	}
	
	public static class UnitComponentSystem
	{
		public static void Add(this UnitComponent self, Unit unit)
		{
			self.idUnits.Add(unit.Id, unit);
			unit.Parent = self;
			var camp = unit.GetCamp();
			if (!self.CampUnits.ContainsKey(camp))
				self.CampUnits[camp] = new HashSet<long>();
			self.CampUnits[camp].Add(unit.Id);
			
			if (!self.ConfigUnits.ContainsKey(unit.ConfigId))
				self.ConfigUnits[unit.ConfigId] = new HashSet<long>();
			self.ConfigUnits[unit.ConfigId].Add(unit.Id);
		}

		public static void ChangeCamp(this UnitComponent self, long id,int oldCamp, int newCamp)
		{
			Unit unit;
			self.idUnits.TryGetValue(id, out unit);
			if (unit == null)
				return;
			self.CampUnits[oldCamp].Remove(id);
			self.CampUnits[newCamp].Add(id);
		}

		public static Unit Get(this UnitComponent self, long id)
		{
			Unit unit;
			self.idUnits.TryGetValue(id, out unit);
			return unit;
		}
		
		public static Unit GetOneByConfigId(this UnitComponent self, int configId)
		{
			self.ConfigUnits.TryGetValue(configId, out var units);
			if (units == null || units.Count == 0)
				return null;
			return self.Get(units.First());
		}

		public static void Remove(this UnitComponent self, long id)
		{
			Unit unit;
			self.idUnits.TryGetValue(id, out unit);
			if (unit != null)
			{
				var camp = unit.GetCamp();
				self.CampUnits[camp].Remove(unit.Id);
				self.ConfigUnits[unit.ConfigId].Remove(unit.Id);
			}
			
			

			self.idUnits.Remove(id);
			unit?.Dispose();
		}

		public static void RemoveNoDispose(this UnitComponent self, long id)
		{
			Unit unit;
			self.idUnits.TryGetValue(id, out unit);
			if (unit != null)
			{
				var camp = unit.GetCamp();
				self.CampUnits[camp].Remove(unit.Id);
				self.ConfigUnits[unit.ConfigId].Remove(unit.Id);
			}
			self.idUnits.Remove(id);
		}

		public static Unit GetMyUnit(this Entity self)
		{
			return self.CurrScene().GetComponent<UnitComponent>().MyUnit;
		}
	}
}