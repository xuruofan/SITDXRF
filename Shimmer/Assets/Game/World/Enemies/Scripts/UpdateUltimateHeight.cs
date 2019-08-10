using Shimmer.Common.Variables;
using UnityEngine;

namespace Shimmer.Game.World.Enemies
{
	public class UpdateUltimateHeight : MonoBehaviour
	{
		public FloatReference PlayerHeight;

		private void OnEnable()
		{
			Vector3 pos = gameObject.transform.position;
			if (pos.y < PlayerHeight.GetValue())
			{
				pos.y = PlayerHeight.GetValue();
			}

			gameObject.transform.position = pos;

			enabled = false;
		}
	}
}