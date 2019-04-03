using Shimmer.Common.Variables;
using UnityEngine;

namespace Shimmer.Game.World.Segments
{
	public class ChooseOne : MonoBehaviour
	{
		private void OnEnable()
		{
			int count = transform.childCount;

			int chosen = Random.Range(0, count);

			for (int i = 0; i < count; i++)
			{
				var obj = transform.GetChild(i).gameObject;
				obj.SetActive(i == chosen);
			}
		}
	}
}