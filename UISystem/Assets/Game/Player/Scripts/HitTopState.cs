using UnityEngine;

namespace Shimmer.Game.Player
{
	public class HitTopState : PlayerState
	{
		public override void OnStateEnter(Animator _animator, AnimatorStateInfo _animatorStateInfo, int _layerIndex)
		{
			base.OnStateEnter(_animator, _animatorStateInfo, _layerIndex);

			m_PlayerBody.bodyType = RigidbodyType2D.Static;
		}

		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			m_PlayerBody.bodyType = RigidbodyType2D.Dynamic;

			base.OnStateExit(animator, stateInfo, layerIndex);
		}
	}
}