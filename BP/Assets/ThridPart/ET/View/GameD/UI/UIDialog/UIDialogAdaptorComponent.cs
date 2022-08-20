using ET;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

namespace ET
{

	public class UIDialogAdaptorComponent : Entity
	{
		public UIDialogViewComponent ViewCom { get => this.Parent as UIDialogViewComponent ;}
	}
}
