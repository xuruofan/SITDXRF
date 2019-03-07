using Shimmer.Common.Variables;
using UnityEngine;

namespace Shimmer.Game.World
{
	public class SparkController : MonoBehaviour
	{
		private void Update()
		{
			gameObject.transform.Rotate(0, 0, -1);
		}
	}
}