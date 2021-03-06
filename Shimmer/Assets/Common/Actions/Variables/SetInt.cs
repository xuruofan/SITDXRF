﻿using System;
using Shimmer.Common.Variables;
using UnityEngine;
using UnityEngine.Assertions;

namespace Shimmer.Common.Actions.Variables
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
				return "Variables/Set int";
			}
		}

		public override void Execute(MonoBehaviour _behaviour)
		{
			Assert.IsNotNull(Variable, "Please set a Variable!");

			Variable.SetValue(Value.GetValue());
		}
	}

}