using UnityEngine;

namespace Shimmer.Game.Player
{
	public class HorizontalJumpState : PlayerState
	{
		public override void OnStateEnter(Animator _animator, AnimatorStateInfo _animatorStateInfo, int _layerIndex)
		{
			base.OnStateEnter(_animator, _animatorStateInfo, _layerIndex);

			m_PlayerBody.bodyType = RigidbodyType2D.Static;
		}

		public override void OnStateExit(Animator _animator, AnimatorStateInfo _stateInfo, int _layerIndex)
		{
			m_PlayerBody.bodyType = RigidbodyType2D.Dynamic;

			Vector2 newVelocity;

			if (m_Player.IsFacingRight)
			{
				newVelocity = new Vector2(m_Player.MAX_X_SPEED, m_Player.MAX_Y_SPEED);
			}
			else
			{
				newVelocity = new Vector2(-m_Player.MAX_X_SPEED, m_Player.MAX_Y_SPEED);
			}

			m_PlayerBody.velocity = newVelocity;

			base.OnStateExit(_animator, _stateInfo, _layerIndex);
		}
	}
}