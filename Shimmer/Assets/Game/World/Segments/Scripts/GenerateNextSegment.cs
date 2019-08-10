using Shimmer.Common.Variables;
using UnityEngine;

namespace Shimmer.Game.World.Segments
{
	/// <summary>
	/// Generate the next segment from a pool of prefabs
	/// </summary>
	[RequireComponent(typeof(Collider2D))]
	public class GenerateNextSegment : MonoBehaviour
	{
		[SerializeField]
		private GameObject m_ParentObject;
		[SerializeField]
		private RectTransform m_NextSpawnPoint;
		[SerializeField]
		private PrefabListVariable m_Prefabs;

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if(collision.gameObject.tag == "Player")
			{
				PrefabList prefabs = m_Prefabs.GetValue();

				Transform cur = transform;
				Transform parent = cur;

				while (cur != null)
				{
					parent = cur;
					cur = cur.parent;
				}

				// Choose a random prefab from the prefab list (that is not the same as the current segment) and randomly flips the instance for more variaty
				var nextPrefab = prefabs.Items[Random.Range(0, prefabs.Items.Length)];
				
				while (m_ParentObject.name.StartsWith(nextPrefab.name))
				{
					nextPrefab = prefabs.Items[Random.Range(0, prefabs.Items.Length)];
				}

				GameObject nextSegObject = Instantiate(nextPrefab, parent);
				nextSegObject.transform.position = m_NextSpawnPoint.position;
				bool bFlip = Random.Range(0, 2) == 1;
				if (bFlip)
				{
					Vector3 scale = nextSegObject.transform.localScale;
					scale.x = -scale.x;
					nextSegObject.transform.localScale = scale;
				}

				// Turn off collider to avoid repeated triggering
				var collider = gameObject.GetComponent<Collider2D>();
				collider.enabled = false;
			}
		}
	}
}