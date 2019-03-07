using UnityEngine;

namespace Shimmer.Common.Variables
{
    [CreateAssetMenu(fileName = "V_IntConstant_New", menuName = "Shimmer/Common/Variables/Int Constant")]
    public class IntConstant : IntVariable
    {
		public override void SetValue(int _value)
		{
			Debug.LogError("Attempt to set value on a constant int variable!");
		}
	}
}