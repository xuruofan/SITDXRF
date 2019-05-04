using Shimmer.UI.Common;
using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace Shimmer.Common.Actions.UI
{
	[Serializable]
	public class GoBack : Action
	{
		public UIManager Manager;

		public static string MenuName
		{
			get
			{
				return "UI/Go back";
			}
		}

		public override void Execute(MonoBehaviour _behaviour)
		{
			Assert.IsNotNull(Manager, "Please specify a UI manager!");
			Manager.Back();
		}
	}

}