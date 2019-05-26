using Shimmer.Common.Variables;
using UnityEngine;

namespace Shimmer.Game.World.Others
{
	public class UpdateHeight : MonoBehaviour
	{
		public BoolReference Reset;
		public FloatReference PlayerHeight;
		public FloatReference RisePerSecond;

		private void Update()
		{
			Vector3 pos = gameObject.transform.position;
			pos.y += RisePerSecond.GetValue() * Time.deltaTime;

			gameObject.transform.position = pos;
		}

		private void OnEnable()
		{
			PlayerHeight.Subscribe(OnHeightChanged);
			Reset.Subscribe(OnResetRequest);
		}

		private void OnDisable()
		{
			PlayerHeight.Unsubscribe(OnHeightChanged);
			Reset.Unsubscribe(OnResetRequest);
		}

		private void OnHeightChanged()
		{
			Vector3 pos = gameObject.transform.position;
			float playerHeight = PlayerHeight.GetValue();

			if (playerHeight > pos.y)
			{
				pos.y = PlayerHeight.GetValue();
				gameObject.transform.position = pos;
			}
		}

		private void OnResetRequest()
		{
			Vector3 pos = gameObject.transform.position;
			pos.y = 0;

			gameObject.transform.position = pos;
		}
	}
}