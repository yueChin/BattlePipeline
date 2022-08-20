using System.Collections.Generic;
using System.Linq;

namespace ET
{
	
	public class UnitComponent: Entity
	{
		public Dictionary<long, Unit> idUnits = new Dictionary<long, Unit>();
		public Dictionary<int, HashSet<long>> CampUnits = new Dictionary<int, HashSet<long>>();
		public Dictionary<int, HashSet<long>> ConfigUnits = new Dictionary<int, HashSet<long>>();
		public Unit MyUnit;
	}
}