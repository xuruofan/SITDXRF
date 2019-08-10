using UnityEngine;

namespace Shimmer.Game.Player
{
	public class SpotJumpState : PlayerState
	{
		public override void OnStateEnter(Animator _animator, AnimatorStateInfo _animatorStateInfo, int _layerIndex)
		{
			Debug.Log("Enter Jump State.");

			base.OnStateEnter(_animator, _animatorStateInfo, _layerIndex);

			m_PlayerBody.bodyType = RigidbodyType2D.Static;
		}

		public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			base.OnStateUpdate(animator, stateInfo, layerIndex);

			if (CanJump(stateInfo.normalizedTime))
			{
				Debug.Log("Start jumping");

				m_PlayerBody.bodyType = RigidbodyType2D.Dynamic;

				m_PlayerBody.velocity = new Vector2(0, m_Player.MAX_Y_SPEED);

				LeaveState();
			}
		}

		public override void OnStateExit(Animator _animator, AnimatorStateInfo _stateInfo, int _layerIndex)
		{
			Debug.Log("Exit Jump State.");

			base.OnStateExit(_animator, _stateInfo, _layerIndex);
		}

		private bool CanJump(float _normalizedTime)
		{
			return _normalizedTime > 1.0f && RigidbodyType2D.Static == m_PlayerBody.bodyType;
		}
	}
}