using UnityEngine;
using UnityEngine.Animations;

namespace Shimmer.Game.Player
{
	public class UpState : PlayerState
	{
		public override void OnStateEnter(Animator _animator, AnimatorStateInfo _animatorStateInfo, int _layerIndex)
		{
			Debug.Log("Enter Up State");

			base.OnStateEnter(_animator, _animatorStateInfo, _layerIndex);

			m_Player.OnCollisionExited += OnCollide;
		}

		public override void OnStateUpdate(Animator _animator, AnimatorStateInfo _animatorStateInfo, int _layerIndex)
		{
			base.OnStateUpdate(_animator, _animatorStateInfo, _layerIndex);

			if (!_animator.IsInTransition(_layerIndex) && !m_IsLeaving && m_Player.LastVelocity.y < -float.Epsilon)
			{
				LeaveState();
				m_Animator.SetTrigger("tDown");
			}
		}

		public override void OnStateExit(Animator _animator, AnimatorStateInfo _animatorStateInfo, int _layerIndex)
		{
			Debug.Log("Exit Up State");

			m_Player.OnCollisionExited -= OnCollide;

			base.OnStateExit(_animator, _animatorStateInfo, _layerIndex);
		}

		protected void OnCollide(Collision2D _collision)
		{
			if (m_IsLeaving)
			{
				return;
			}

			if (IsCollidingTop())
			{
				m_Animator.SetTrigger("tCollideTop");
			}
			else
			{
				m_Animator.SetTrigger("tDown");
			}

			LeaveState();
		}

		protected override void LeaveState()
		{
			base.LeaveState();
		}
	}
}