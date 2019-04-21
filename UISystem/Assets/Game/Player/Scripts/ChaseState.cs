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
			Debug.Log("Enter Chase State.");

			base.OnStateEnter(_animator, _stateInfo, _layerIndex);

			m_Player.OnCollisionExited += OnCollide;
		}

		public override void OnStateUpdate(Animator _animator, AnimatorStateInfo _stateInfo, int _layerIndex)
		{
			if (m_IsLeaving)
			{
				return;
			}

			Vector2 pointerPosition = m_InputController.WorldPosition;
			Vector2 direction = (pointerPosition - m_PlayerBody.position).normalized;
			float magnitude = new Vector2(m_Player.MAX_X_SPEED, m_Player.MAX_Y_SPEED).magnitude;
			Vector2 newVelocity = magnitude * direction;
			Vector2 curVelocity = m_PlayerBody.velocity;
			Vector2 finalVelocity = TurnSpeed * newVelocity + (1.0f - TurnSpeed) * curVelocity;

			Vector3 upVector = m_Player.Visual.transform.up;
			upVector = Vector3.RotateTowards(upVector, m_PlayerBody.velocity.normalized, Time.deltaTime, 0.0f);

			m_Player.Visual.transform.up = upVector;

			m_Player.Visual.transform.localScale = (finalVelocity.x < float.Epsilon) ? new Vector2(-1, 1) : new Vector2(1, 1);

			m_PlayerBody.velocity = finalVelocity;

			m_Player.SpendCharge(Time.deltaTime);

			if (m_Player.Charge < float.Epsilon)
			{
				LeaveState();
				m_Animator.SetTrigger("tUp");
			}
		}

		public override void OnStateExit(Animator _animator, AnimatorStateInfo _stateInfo, int _layerIndex)
		{
			Debug.Log("Exit Chase State");

			m_Player.OnCollisionExited -= OnCollide;

			base.OnStateExit(_animator, _stateInfo, _layerIndex);
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
				m_Animator.SetTrigger("tFall");
			}

			LeaveState();
		}

		protected override void HandleInput()
		{
			if (m_IsLeaving)
			{
				return;
			}

			EInputPhase phase = (EInputPhase)m_InputController.Phase.GetValue();

			if (phase == EInputPhase.End)
			{
				LeaveState();
				m_Animator.SetTrigger("tUp");
			}
		}

		protected override void LeaveState()
		{
			if (m_IsLeaving)
			{
				return;
			}

			base.LeaveState();

			m_Player.ResetCharge();
		}
	}
}