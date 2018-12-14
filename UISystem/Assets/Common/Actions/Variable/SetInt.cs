using System;
using Shimmer.Common.Variables;
using UnityEngine.Assertions;

namespace Shimmer.Common.Actions.Variable
{
	[Serializable]
	public class SetInt : Action
	{
		public IntVariable Variable;

		public override void Execute()
		{
			Assert.IsNotNull(Variable, "Please set a Variable!");
			Variable.SetValue(0);
		}
	}

}