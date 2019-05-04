using Shimmer.Common.Variables;
using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace Shimmer.Common.Actions.Actions
{
	[Serializable]
	public class ActivateGameObject : Action
	{
		public GameObject GameObject;
		public bool Not;
		public BoolReference Active;

		public static string MenuName
		{
			get
			{
				return "Actions/Activate GameObject";
			}
		}

		public override void Execute(MonoBehaviour _behaviour)
		{
			Assert.IsNotNull(GameObject, "GameObject to be activated is null!");

			GameObject.SetActive(Not ? Active.GetValue() == false : Active.GetValue());
		}
	}

}