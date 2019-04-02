using Shimmer.Common.Variables;
using Shimmer.Game.InputControl;
using UnityEngine;

namespace Shimmer.Game.Player
{
	public class ChaseState : PlayerState
	{
		public FloatReference Charge;
		public float TurnSpeed = 0.5f;

		public override void OnStateEnter(Animator _animator, AnimatorStateInfo _stateInfo, int _layerIndex)
		{
			base.OnStateEnter(_animator, _stateInfo, _layerIndex);
		}

		public override void OnStateUpdate(Animator _animator, AnimatorStateInfo _stateInfo, int _layerIndex)
		{
			base.OnStateUpdate(_animator, _stateInfo, _layerIndex);

			Vector2 pointerPosition = m_InputController.WorldPosition;
			Vector2 direction = (pointerPosition - m_PlayerBody.position).normalized;
			float magnitude = new Vector2(m_Player.MAX_X_SPEED, m_Player.MAX_Y_SPEED).magnitude;
			Vector2 newVelocity = magnitude * direction;
			Vector2 curVelocity = m_PlayerBody.velocity;
			m_PlayerBody.velocity = TurnSpeed * newVelocity + (1.0f - TurnSpeed) * curVelocity;

			float chargeLeft = Charge.GetValue() - Time.deltaTime;
			if (chargeLeft < 0)
			{
				m_Animator.SetTrigger("tDown");
			}
			else
			{
				Charge.SetValue(chargeLeft);
			}
		}

		public override void OnStateExit(Animator _animator, AnimatorStateInfo _stateInfo, int _layerIndex)
		{
			ResetCharge();

			base.OnStateExit(_animator, _stateInfo, _layerIndex);
		}

		protected override void HandleInput()
		{
			EInputPhase phase = (EInputPhase)m_InputController.Phase.GetValue();

			if (phase == EInputPhase.End)
			{
				m_Animator.SetTrigger("tDown");
			}
		}

		private void ResetCharge()
		{
			Charge.SetValue(m_Player.MaxCharge.GetValue());
		}
	}
}