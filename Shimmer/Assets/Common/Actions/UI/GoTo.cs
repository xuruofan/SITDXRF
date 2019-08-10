using Shimmer.UI.Common;
using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace Shimmer.Common.Actions.UI
{
	[Serializable]
	public class GoTo : Action
	{
		public UIManager Manager;
		public GameObject Page;

		public static string MenuName
		{
			get
			{
				return "UI/Go to";
			}
		}

		public override void Execute(MonoBehaviour _behaviour)
		{
			Assert.IsNotNull(Manager, "Cannot go to a page without a manager!");
			Assert.IsNotNull(Page, "Cannot got to a page without specifying a page!");
			Manager.GoTo(Page);
		}
	}

}