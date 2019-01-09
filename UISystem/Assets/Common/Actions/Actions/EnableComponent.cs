using Shimmer.Common.Variables;
using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace Shimmer.Common.Actions.Actions
{
	[Serializable]
	public class EnableComponent : Action
	{
		public MonoBehaviour Component;
		public bool Not;
		public BoolReference Enabled;

		public static string MenuName
		{
			get
			{
				return "Actions/Enable component";
			}
		}

		public override void Execute()
		{
			Assert.IsNotNull(Component, "Component to be enabled is null!");

			Component.enabled = Not ? Enabled.GetValue() == false : Enabled.GetValue();
		}
	}

}