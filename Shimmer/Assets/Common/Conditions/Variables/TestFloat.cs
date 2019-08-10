using Shimmer.Common.Variables;
using System;

namespace Shimmer.Common.Conditions.Variables
{
	public enum FloatOperator
	{
		EqualTo,
		NotEqualTo,
		GreaterThan,
		LessThan
	}

	[Serializable]
	public class TestFloat : Condition
	{
		public static string MenuName
		{
			get
			{
				return "Variables/Test float";
			}
		}

		public FloatReference A;
		public FloatOperator Operator;
		public FloatReference B;

		public override bool Evaluate()
		{

			return false;
		}
	}
}