using UnityEngine;

namespace Shimmer.Game.Player
{
	public class JumpState : PlayerState
	{
		public override void OnStateEnter(Animator _animator, AnimatorStateInfo _stateInfo, int _layerIndex)
		{
			base.OnStateEnter(_animator, _stateInfo, _layerIndex);

			bool bIsMovingRight = m_PlayerBody.velocity.x > 0;

			if (bIsMovingRight)
			{
				m_PlayerBody.velocity = new Vector2(m_Player.MAX_X_SPEED, m_Player.MAX_Y_SPEED);
			}
			else
			{
				m_PlayerBody.velocity = new Vector2(-m_Player.MAX_X_SPEED, m_Player.MAX_Y_SPEED);
			}

			_animator.SetTrigger("tUp");
		}
	}
}