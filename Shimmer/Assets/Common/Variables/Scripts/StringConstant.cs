using UnityEngine;

namespace Shimmer.Common.Variables
{
    [CreateAssetMenu(fileName = "V_StringConstant_New", menuName = "Shimmer/Common/Variables/String Constant")]
    public class StringConstant : StringVariable
    {
		public override void SetValue(string _value)
		{
			Debug.LogError("Attempt to set value on a constant string variable!");
		}
	}
}