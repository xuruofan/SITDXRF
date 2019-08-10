using Shimmer.Common.Variables;
using UnityEngine;

namespace Shimmer.Game.World.Others
{
	public class UpdateCameraSize : MonoBehaviour
	{
		public float Width;

		private void Awake()
		{
			float height = Width / Camera.main.aspect;
			Camera.main.orthographicSize = height;
		}
	}
}