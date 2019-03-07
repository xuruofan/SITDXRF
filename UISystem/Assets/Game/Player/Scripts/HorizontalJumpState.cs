using UnityEngine;

namespace Shimmer.Game.Player
{
	public class HorizontalJumpState : PlayerState
	{
		public override void OnStateEnter(Animator _animator, AnimatorStateInfo _animatorStateInfo, int _layerIndex)
		{
			base.OnStateEnter(_animator, _animatorStateInfo, _layerIndex);

			m_PlayerBody.velocity = new Vector2(0, 0);
		}

		public override void OnStateExit(Animator _animator, AnimatorStateInfo _stateInfo, int _layerIndex)
		{
			base.OnStateExit(_animator, _stateInfo, _layerIndex);

			if (m_Player.IsFacingRight)
			{
				m_PlayerBody.velocity = new Vector2(m_Player.MAX_X_SPEED, m_Player.MAX_Y_SPEED);
			}
			else
			{
				m_PlayerBody.velocity = new Vector2(-m_Player.MAX_X_SPEED, m_Player.MAX_Y_SPEED);
			}
		}
	}
}