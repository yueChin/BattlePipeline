using ET;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

namespace ET
{

	public class UIMapAdaptorComponent : Entity
	{
		public UIMapViewComponent ViewCom { get => this.Parent as UIMapViewComponent ;}
	}
}
