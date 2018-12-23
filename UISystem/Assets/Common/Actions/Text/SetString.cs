using Shimmer.Common.Variables;
using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace Shimmer.Common.Actions.Text
{
	[Serializable]
	public class SetString : Action
	{
		public StringVariable String;
		public StringReference Value;

		public static string MenuName
		{
			get
			{
				return "Text/Set string";
			}
		}

		public override void Execute()
		{
			Assert.IsNotNull(String);

			String.SetValue(Value.GetValue());
		}
	}

}