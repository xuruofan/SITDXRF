using Shimmer.Common.Variables;
using System;

namespace Shimmer.Common.Conditions.Variables
{
	[Serializable]
	public class TestString : Condition
	{
		public static string MenuName
		{
			get
			{
				return "Variables/Test string";
			}
		}

		public StringReference A;
		public StringReference B;

		public override bool Evaluate()
		{
			return A.GetValue() == B.GetValue();
		}
	}
}