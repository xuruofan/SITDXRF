using UnityEngine;

namespace Shimmer.Game.Player
{
	public class DownState : PlayerState
	{
		public override void OnStateEnter(Animator _animator, AnimatorStateInfo _animatorStateInfo, int _layerIndex)
		{
			Debug.Log("Enter Down State");

			base.OnStateEnter(_animator, _animatorStateInfo, _layerIndex);

			m_Player.OnCollisionExited += OnCollide;
		}

		public override void OnStateExit(Animator _animator, AnimatorStateInfo _animatorStateInfo, int _layerIndex)
		{
			Debug.Log("Exit Down State");

			m_Player.OnCollisionExited -= OnCollide;

			base.OnStateExit(_animator, _animatorStateInfo, _layerIndex);
		}

		protected void OnCollide(Collision2D _collision)
		{
			if (m_IsLeaving)
			{
				return;
			}
				
			if (IsCollidingHorizontal())
			{
				m_Animator.SetTrigger("tCollideHorizontally");
				
				LeaveState();
			}
		}
	}
}