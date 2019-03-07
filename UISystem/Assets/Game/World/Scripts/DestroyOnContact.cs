using UnityEngine;

namespace Shimmer.Game.World
{
	public class DestroyOnContact : MonoBehaviour
	{
		private void Start()
		{
			Debug.Log("DestroyOnContact started");	
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.gameObject.tag == "DestroyByUltimate")
			{
				GameObject.Destroy(collision.gameObject);
			}
		}
	}
}