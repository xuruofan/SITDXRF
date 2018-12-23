using Shimmer.Common.Variables;
using System;

namespace Shimmer.Common.Conditions.Variable
{
	[Serializable]
	public class TestString : Condition
	{
		public static string MenuName
		{
			get
			{
				return "Variable/Test string";
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