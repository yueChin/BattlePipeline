using ET;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

namespace ET
{

	public class UIBattleHudAdaptorComponent : Entity
	{
		public UIBattleHudViewComponent ViewCom { get => this.Parent as UIBattleHudViewComponent ;}

		public Queue<GameObject> TempHuds = new Queue<GameObject>();
		
		public Queue<GameObject> TempHPBars = new Queue<GameObject>();

		public Dictionary<GameObject, long> DisposeTimer = new Dictionary<GameObject, long>();

		public Dictionary<long, GameObject> Id2HPBars = new Dictionary<long, GameObject>();

		public Dictionary<long, long> DisposeHPBarTimer = new Dictionary<long, long>();
	}
}
