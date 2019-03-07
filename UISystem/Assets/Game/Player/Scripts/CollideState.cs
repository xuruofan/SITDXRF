using UnityEngine;

namespace Shimmer.Game.Player
{
	public class CollideState : PlayerState
	{
		public override void OnStateEnter(Animator _animator, AnimatorStateInfo _stateInfo, int _layerIndex)
		{
			base.OnStateEnter(_animator, _stateInfo, _layerIndex);

			// There are 3 types of collisions:
			// 1. Colliding vertically causes the player to flip direction and jump up
			// 2. Colliding horizontally causes the player to continue jumping in the same direction
			// 3. Colliding on top causes the player to fall

			
		}


	}
}