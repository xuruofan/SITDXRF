using UnityEngine;

namespace Shimmer.Game.World.Enemies
{
	public class DestroyOnContact : MonoBehaviour
	{
		private void Start()
		{
			Debug.Log("DestroyOnContact started");	
		}

		private void OnTriggerEnter2D(Collider2D _collision)
		{
			string tag = _collision.gameObject.tag;

			if (tag == "DestroyByUltimate")
			{
				GameObject.Destroy(_collision.gameObject);
			}
			else if (tag == "Player")
			{
				var player = _collision.gameObject.GetComponent<Player.Player>();
				player.Kill();
			}
		}
	}
}