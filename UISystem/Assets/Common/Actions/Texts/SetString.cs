using Shimmer.Common.Variables;
using System;
using UnityEngine.Assertions;

namespace Shimmer.Common.Actions.Texts
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
				return "Texts/Set string";
			}
		}

		public override void Execute()
		{
			Assert.IsNotNull(String);

			String.SetValue(Value.GetValue());
		}
	}

}