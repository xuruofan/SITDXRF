using UnityEngine;

namespace Shimmer.Game.Player
{
	public class HitTopState : PlayerState
	{
		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			base.OnStateUpdate(animator, stateInfo, layerIndex);
			
			m_PlayerBody.velocity = new Vector2(0, 0);
		}
	}
}