using ET;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

namespace ET
{

	public class UIInventoryAdaptorComponent : Entity
	{
		public UIInventoryViewComponent ViewCom { get => this.Parent as UIInventoryViewComponent ;}

		// 道具栏，位置对应的Go
		public Dictionary<int, GameObject> Pos2Grid = new Dictionary<int, GameObject>();
	
		//装备栏，装备点对应的戒指
		public Dictionary<int, GameObject> EquipPoint2Go = new Dictionary<int, GameObject>();
	}
}
