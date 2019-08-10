using UnityEngine;

namespace Shimmer.Game.Player
{
	public class HitTopState : PlayerState
	{
		public override void OnStateEnter(Animator _animator, AnimatorStateInfo _animatorStateInfo, int _layerIndex)
		{
			Debug.Log("Enter Hit Top State.");
			
			base.OnStateEnter(_animator, _animatorStateInfo, _layerIndex);

			m_PlayerBody.bodyType = RigidbodyType2D.Static;
		}

		public override void OnStateUpdate(Animator _animator, AnimatorStateInfo _stateInfo, int _layerIndex)
		{
			base.OnStateUpdate(_animator, _stateInfo, _layerIndex);
			
			if (CanLeave(_stateInfo.normalizedTime))
			{
				m_PlayerBody.bodyType = RigidbodyType2D.Dynamic;
				LeaveState();
			}
		}

		public override void OnStateExit(Animator _animator, AnimatorStateInfo _stateInfo, int _layerIndex)
		{
			Debug.Log("Exit Hit Top State.");

			base.OnStateExit(_animator, _stateInfo, _layerIndex);
		}

		private bool CanLeave(float _normalizedTime)
		{
			return _normalizedTime > 0.25f && RigidbodyType2D.Static == m_PlayerBody.bodyType;
		}
	}
}