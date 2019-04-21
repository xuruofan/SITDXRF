using UnityEngine;

namespace Shimmer.Game.Player
{
	public class FallState : PlayerState
	{
		public override void OnStateEnter(Animator _animator, AnimatorStateInfo _animatorStateInfo, int _layerIndex)
		{
			Debug.Log("Enter Fall State");

			base.OnStateEnter(_animator, _animatorStateInfo, _layerIndex);

			m_Player.OnCollisionExited += OnCollide;

			m_PlayerBody.velocity = Vector2.zero;
		}

		public override void OnStateExit(Animator _animator, AnimatorStateInfo _animatorStateInfo, int _layerIndex)
		{
			Debug.Log("Exit Fall State");

			m_Player.OnCollisionExited -= OnCollide;

			base.OnStateExit(_animator, _animatorStateInfo, _layerIndex);
		}

		protected void OnCollide(Collision2D _collision)
		{
			if (m_IsLeaving)
			{
				return;
			}

			m_Animator.SetTrigger("tCollideHorizontally");

			LeaveState();
		}
	}
}