using Shimmer.Common.Variables;
using UnityEngine;

namespace Shimmer.Game.World.Others
{
	public class UpdateCameraHeight : MonoBehaviour
	{
		public FloatReference PlayerHeight;

		private void OnEnable()
		{
			PlayerHeight.Subscribe(UpdateHeight);
		}

		private void OnDisable()
		{
			PlayerHeight.Unsubscribe(UpdateHeight);
		}

		private void UpdateHeight()
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