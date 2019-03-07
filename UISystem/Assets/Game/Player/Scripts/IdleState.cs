using UnityEngine;

namespace Shimmer.Game.Player
{
	public class IdleState : StateMachineBehaviour
	{
		public override void OnStateExit(Animator _animator, AnimatorStateInfo _stateInfo, int _layerIndex)
		{
			base.OnStateExit(_animator, _stateInfo, _layerIndex);

			Rigidbody2D body = _animator.gameObject.GetComponent<Rigidbody2D>();
			body.bodyType = RigidbodyType2D.Dynamic;
		}
	}
}