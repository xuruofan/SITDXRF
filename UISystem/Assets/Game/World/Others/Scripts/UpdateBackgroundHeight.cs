using Shimmer.Common.Variables;
using UnityEngine;

namespace Shimmer.Game.World.Others
{
	public class UpdateBackgroundHeight : MonoBehaviour
	{
		public FloatReference PlayerHeight;

		private void OnEnable()
		{
			PlayerHeight.Subscribe(OnHeightChanged);
		}

		private void OnDisable()
		{
			PlayerHeight.Unsubscribe(OnHeightChanged);
		}

		private void OnHeightChanged()
		{
			Vector3 pos = gameObject.transform.position;
			pos.y = PlayerHeight.GetValue();
			if (pos.y < 0)
			{
				pos.y = 0;
			}

			gameObject.transform.position = pos;
		}
	}
}