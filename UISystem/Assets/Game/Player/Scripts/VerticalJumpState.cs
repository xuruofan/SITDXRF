using UnityEngine;
using UnityEngine.Animations;

namespace Shimmer.Game.Player
{
	public class VerticalJumpState : PlayerState
	{
		public override void OnStateEnter(Animator _animator, AnimatorStateInfo _stateInfo, int _layerIndex)
		{
			Debug.Log("Enter Vertical Jump State");

			base.OnStateEnter(_animator, _stateInfo, _layerIndex);

			m_PlayerBody.bodyType = RigidbodyType2D.Static;
		}

		public override void OnStateExit(Animator _animator, AnimatorStateInfo _stateInfo, int _layerIndex)
		{
			Debug.Log("Exit Vertical Jump State.");

			m_PlayerBody.bodyType = RigidbodyType2D.Dynamic;

			// Flip image
			Vector2 scale = m_Player.Visual.transform.localScale;
			scale.x *= -1;
			m_Player.Visual.transform.localScale = scale;
			
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