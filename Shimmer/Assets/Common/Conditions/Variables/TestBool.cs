using Shimmer.Common.Variables;
using System;

namespace Shimmer.Common.Conditions.Variables
{
	[Serializable]
	public class TestBool : Condition
	{
		public static string MenuName
		{
			get
			{
				return "Variables/Test bool";
			}
		}

		public BoolReference A;
		public BoolReference B;

		public override bool Evaluate()
		{
			return A.GetValue() == B.GetValue();
		}
	}
}