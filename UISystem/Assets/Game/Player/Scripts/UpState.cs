using UnityEngine;

namespace Shimmer.Game.Player
{
	public class UpState : PlayerState
	{
		public override void OnStateUpdate(Animator _animator, AnimatorStateInfo _animatorStateInfo, int _layerIndex)
		{
			base.OnStateUpdate(_animator, _animatorStateInfo, _layerIndex);
			
			if (m_PlayerBody.velocity.y < -float.Epsilon)
			{
				_animator.SetTrigger("tDown");
			}
		}
	}
}