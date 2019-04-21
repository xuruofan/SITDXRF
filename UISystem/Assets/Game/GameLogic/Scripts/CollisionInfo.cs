
using UnityEngine;

namespace Shimmer.Game.GameLogic
{
	public enum ECollisionBehaviour
	{
		Horizontal,
		Vertical,
		Ceiling,
		KnockBack
	}

	[RequireComponent(typeof(Collider2D))]
	public class CollisionInfo : MonoBehaviour
	{
		[SerializeField]
		private ECollisionBehaviour m_Behaviour;

		public ECollisionBehaviour Behaviour => m_Behaviour;
	}
}