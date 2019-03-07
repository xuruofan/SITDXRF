using UnityEngine;

namespace Shimmer.Game.Player
{
	public class VerticalJumpState : PlayerState
	{
		public override void OnStateExit(Animator _animator, AnimatorStateInfo _stateInfo, int _layerIndex)
		{
			base.OnStateExit(_animator, _stateInfo, _layerIndex);

			m_Player.IsFacingRight = !m_Player.IsFacingRight;

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