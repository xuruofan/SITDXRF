using Shimmer.Common.Actions;
using UnityEngine;

namespace Shimmer.Game.World.Pickups
{
	public abstract class PickupControllerBase : MonoBehaviour
	{
		public ActionList OnCollected;
		public float DelayDestroy;

		private void OnTriggerEnter2D(Collider2D _collision)
		{
			var obj = _collision.gameObject;

			var player = obj.GetComponent<Player.Player>();

			if (null != player)
			{
				ApplyEffect(player);

				GameObject.Destroy(gameObject, DelayDestroy);
			}
		}

		protected virtual void ApplyEffect(Player.Player _player)
		{
			OnCollected.Execute(this);
		}
	}
}