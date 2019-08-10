using System;
using Shimmer.Common.Variables;
using Shimmer.Game.GameLogic;
using Shimmer.Game.InputControl;
using Shimmer.Tools;
using Shimmer.UI.Common;
using UnityEngine;

namespace Shimmer.Game.Player
{
	public class PlayerState : StateMachineBehaviour
	{
		[SerializeField, ReadOnly]
		protected Player m_Player;
		protected Rigidbody2D m_PlayerBody;
		protected Animator m_Animator;
		protected InputController m_InputController;
		protected bool m_IsLeaving;

		public override void OnStateEnter(Animator _animator, AnimatorStateInfo _animatorStateInfo, int _layerIndex)
		{
			base.OnStateEnter(_animator, _animatorStateInfo, _layerIndex);

			m_IsLeaving = false;

			m_Animator = _animator;
			m_Player = _animator.gameObject.GetComponent<Player>();
			m_PlayerBody = m_Player.gameObject.GetComponent<Rigidbody2D>();
			m_InputController = GameSetup.Instance.InputController;

			m_InputController.Phase.Subscribe(HandleInput);
		}

		public override void OnStateExit(Animator _animator, AnimatorStateInfo _animatorStateInfo, int _layerIndex)
		{
			base.OnStateExit(_animator, _animatorStateInfo, _layerIndex);

			LeaveState();

			if (m_InputController != null)
			{
				m_InputController.Phase.Unsubscribe(HandleInput);

				m_InputController = null;
			}
		}

		public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			base.OnStateUpdate(animator, stateInfo, layerIndex);
			
			if (m_PlayerBody.bodyType == RigidbodyType2D.Static)
			{
				return;
			}
			
			// Keep horizontal speed constant and vertical speed within a limit
			float yVelocity = m_PlayerBody.velocity.y;
			float xVelocity = m_PlayerBody.velocity.x;

			if (yVelocity < -m_Player.MAX_Y_SPEED)
			{
				yVelocity = -m_Player.MAX_Y_SPEED;
			}

			m_PlayerBody.velocity = new Vector2(xVelocity, yVelocity);

			Vector3 upVector = m_Player.Visual.transform.up;
			if (Vector3.up != upVector)
			{
				m_Player.Visual.transform.up = Vector3.RotateTowards(upVector, Vector3.up, Time.deltaTime, 0.0f);
			}

			// Keep angular 0
			m_PlayerBody.angularVelocity = 0;
		}

		protected bool IsCollidingTop()
		{
			Vector2 oldVelocity = m_Player.LastVelocity;
			Vector2 newVelocity = m_PlayerBody.velocity;

			bool xDirectionOld = oldVelocity.x > 0;
			bool xDirectionNew = newVelocity.x > 0;

			return oldVelocity.y > 0 && newVelocity.y < 0;
		}

		protected bool IsCollidingHorizontal()
		{
			Vector2 newVelocity = m_PlayerBody.velocity;

			if (newVelocity.y < 0)
			{
				return false;
			}

			Vector2 oldVelocity = m_Player.LastVelocity;

			//bool xDirectionOld = oldVelocity.x > 0;
			//bool xDirectionNew = newVelocity.x > 0;
			//bool yDirectionOld = oldVelocity.y > 0;
			//bool yDirectionNew = newVelocity.y > 0;

			//return xDirectionNew == xDirectionOld ||  // Traveling in same x direction
			//	oldVelocity.x == 0 && oldVelocity.y < 0;    // Traveling vertically downwards
			return oldVelocity.y < 0 && newVelocity.y > 0;
		}

		protected virtual void HandleInput()
		{
			if (m_IsLeaving)
			{
				return;
			}

			switch((EInputPhase)m_InputController.Phase.GetValue())
			{
				case EInputPhase.Begin:
					m_Animator.SetTrigger("tChase");
					LeaveState();
					break;
			}
		}

		protected virtual void LeaveState()
		{
			if (m_IsLeaving)
			{
				return;
			}

			m_IsLeaving = true;
		}

		private void OnDisable()
		{
			if (m_InputController != null)
			{
				m_InputController.Phase.Unsubscribe(HandleInput);
			}
		}
	}
}