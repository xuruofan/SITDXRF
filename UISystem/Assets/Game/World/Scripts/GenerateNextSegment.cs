using Shimmer.Common.Variables;
using UnityEngine;

namespace Shimmer.Game.World
{
	[RequireComponent(typeof(Collider2D))]
	public class GenerateNextSegment : MonoBehaviour
	{
		public RectTransform NextSpawnPoint;
		public PrefabListVariable Prefabs;

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if(collision.gameObject.tag == "Player")
			{
				PrefabList prefabs = Prefabs.GetValue();
				Random.Range(0, prefabs.Items.Length);
				GameObject nextSegObject = Instantiate<GameObject>(prefabs.Items[Random.Range(0, prefabs.Items.Length)]);
				nextSegObject.transform.position = NextSpawnPoint.position;
				bool bFlip = Random.Range(0, 2) == 1;
				if (bFlip)
				{
					Vector3 scale = nextSegObject.transform.localScale;
					scale.x = -scale.x;
					nextSegObject.transform.localScale = scale;
				}

				Collider2D collider = gameObject.GetComponent<Collider2D>();
				collider.enabled = false;
			}
		}
	}
}