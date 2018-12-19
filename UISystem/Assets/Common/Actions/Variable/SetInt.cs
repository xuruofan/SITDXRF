﻿using System;
using Shimmer.Common.Variables;
using UnityEngine.Assertions;

namespace Shimmer.Common.Actions.Variable
{
	[Serializable]
	public class SetInt : Action
	{
		public IntVariable Variable;
		public IntReference Value;

		public static string MenuName
		{
			get
			{
				return "Variable/SetInt";
			}
		}

		public override void Execute()
		{
			Assert.IsNotNull(Variable, "Please set a Variable!");

			Variable.SetValue(Value.GetValue());
		}
	}

}