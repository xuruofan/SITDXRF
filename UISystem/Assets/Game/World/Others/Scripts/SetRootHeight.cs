using Shimmer.Common.Variables;
using UnityEngine;

namespace Shimmer.Game.World.Others
{
	public class SetRootHeight : MonoBehaviour
	{
		private void Awake()
		{
			Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, 0, 0));
			pos.z = gameObject.transform.position.z;
			gameObject.transform.position = pos;
		}
	}
}