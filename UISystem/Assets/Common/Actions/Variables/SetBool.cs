using System;
using Shimmer.Common.Variables;
using UnityEngine;
using UnityEngine.Assertions;

namespace Shimmer.Common.Actions.Variables
{
	[Serializable]
	public class SetBool : Action
	{
		public BoolVariable Variable;
		public BoolReference Value;

		public static string MenuName
		{
			get
			{
				return "Variables/Set bool";
			}
		}

		public override void Execute(MonoBehaviour _behaviour)
		{
			Assert.IsNotNull(Variable, "Please set a Variable!");

			Variable.SetValue(Value.GetValue());
		}
	}

}