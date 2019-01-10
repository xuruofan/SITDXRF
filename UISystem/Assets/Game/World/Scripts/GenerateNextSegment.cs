using UnityEngine;

namespace Shimmer.Game.World
{
	[RequireComponent(typeof(Collider2D))]
	public class GenerateNextSegment : MonoBehaviour
	{
		public RectTransform NextSpawnPoint;
		public GameObject Prefab;

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if(collision.gameObject.tag == "Player")
			{
				GameObject nextSegObject = Instantiate<GameObject>(Prefab);
				nextSegObject.transform.position = NextSpawnPoint.position;
			}
		}
	}
}