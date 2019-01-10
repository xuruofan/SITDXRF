using Shimmer.Common.Variables;
using UnityEngine;

namespace Shimmer.Game.World
{
	public class UpdateBackgroundHeight : MonoBehaviour
	{
		public FloatReference PlayerHeight;

		private void OnEnable()
		{
			Vector3 pos = gameObject.transform.position;
			pos.y = PlayerHeight.GetValue();
			if (pos.y < 0)
			{
				pos.y = 0;
			}

			gameObject.transform.position = pos;

			enabled = false;
		}
	}
}