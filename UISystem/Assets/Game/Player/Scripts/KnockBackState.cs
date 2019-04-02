using Shimmer.Game.GameLogic;
using UnityEngine;

namespace Shimmer.Game.Player
{
	public class KnockBackState : PlayerState
	{
		public override void OnStateEnter(Animator _animator, AnimatorStateInfo _stateInfo, int _layerIndex)
		{
			base.OnStateEnter(_animator, _stateInfo, _layerIndex);

			var velocity = m_Player.LastVelocity;
			velocity.x = -velocity.x;
			velocity.y = -velocity.y;

			m_PlayerBody.bodyType = RigidbodyType2D.Dynamic;

			m_PlayerBody.velocity = velocity;
		}
	}
}