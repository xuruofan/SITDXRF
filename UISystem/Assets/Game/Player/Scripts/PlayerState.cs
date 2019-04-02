using System;
using Shimmer.Common.Variables;
using Shimmer.Game.GameLogic;
using Shimmer.Game.InputControl;
using Shimmer.Tools;
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

		public override void OnStateEnter(Animator _animator, AnimatorStateInfo _animatorStateInfo, int _layerIndex)
		{
			base.OnStateEnter(_animator, _animatorStateInfo, _layerIndex);

			m_Animator = _animator;
			m_Player = _animator.gameObject.GetComponent<Player>();
			m_PlayerBody = m_Player.gameObject.GetComponent<Rigidbody2D>();
			m_InputController = m_Player.InputController;

			m_Player.OnCollisionEntered += OnCollide;
			m_InputController.Phase.Subscribe(HandleInput);
		}

		public override void OnStateExit(Animator _animator, AnimatorStateInfo _animatorStateInfo, int _layerIndex)
		{
			base.OnStateExit(_animator, _animatorStateInfo, _layerIndex);

			if (m_Player)
			{
				m_Player.OnCollisionEntered -= OnCollide;
			}

			if (m_InputController != null)
			{
				m_InputController.Phase.Unsubscribe(HandleInput);
			}
		}

		public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			base.OnStateUpdate(animator, stateInfo, layerIndex);
			
			// Keep horizontal speed constant and vertical speed within a limit
			float yVelocity = m_PlayerBody.velocity.y;
			float xVelocity = m_PlayerBody.velocity.x;

			if (yVelocity < -m_Player.MAX_Y_SPEED)
			{
				yVelocity = -m_Player.MAX_Y_SPEED;
			}

			m_PlayerBody.velocity = new Vector2(xVelocity, yVelocity);
			
			// Keep angular 0
			m_PlayerBody.angularVelocity = 0;
		}

		private void OnCollide(Collision2D _collision)
		{
			Vector2 oldVelocity = m_Player.LastVelocity;
			Vector2 newVelocity = m_PlayerBody.velocity;

			bool xDirectionOld = oldVelocity.x > 0;
			bool xDirectionNew = newVelocity.x > 0;

			bool hitTop = oldVelocity.y > 0 && newVelocity.y < 0;
			bool hitHorizontal = xDirectionNew == xDirectionOld ||  // Traveling in same x direction
				oldVelocity.x == 0 && oldVelocity.y < 0;    // Traveling vertically downwards

			if (hitTop)
			{
				m_Animator.SetTrigger("tCollideTop");
			}
			else if (hitHorizontal)	
			{
				m_Animator.SetTrigger("tCollideHorizontally");
			}
			else
			{
				m_Animator.SetTrigger("tCollideVertically");
			}
		}

		protected virtual void HandleInput()
		{
			switch((EInputPhase)m_InputController.Phase.GetValue())
			{
				case EInputPhase.Begin:
					m_Animator.SetTrigger("tChase");
					break;
			}
		}
	}
}