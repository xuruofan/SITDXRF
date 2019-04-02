using System;
using Shimmer.Common.Variables;
using Shimmer.Game.GameLogic;
using Shimmer.Game.InputControl;
using UnityEngine;
using UnityEngine.Assertions;

namespace Shimmer.Game.Player
{
	public class Player : MonoBehaviour
	{
		public delegate void OnCollisionEnterEvent(Collision2D _collision);
		
		public InputController InputController;
		[SerializeField]
		public GameObject Visual;

		public FloatReference Charge;
		public FloatVariable Height;

		public bool IsFacingRight
		{
			get { return Visual.transform.localScale.x > 0; }
		}

		public bool IsMovingRight
		{
			get
			{
				if (RigidbodyType2D.Dynamic == m_Body.bodyType)
				{
					return m_Body.velocity.x > 0;
				}
				else
				{
					return LastVelocity.x > 0;
				}
			}
		}

		public Vector2 LastVelocity { get; private set; } = Vector2.zero;

		private bool m_IsColliding = false;

		[SerializeField]
		private FloatReference MaxXSpeed;
		[SerializeField]
		private FloatReference MaxYSpeed;
		public FloatReference MaxCharge;

		public OnCollisionEnterEvent OnCollisionEntered;

		private Rigidbody2D m_Body = null;

		public float MAX_X_SPEED 
		{
			get
			{
				return MaxXSpeed.GetValue();
			}
		}

		public float MAX_Y_SPEED
		{
			get
			{
				return MaxYSpeed.GetValue();
			}
		}

		private void Awake()
		{
			m_Body = gameObject.GetComponent<Rigidbody2D>();

			Assert.IsNotNull(m_Body, "Rigidbody2D is not found on player gameobject!");

			Charge.SetValue(MaxCharge.GetValue());
		}

		private void Update()
		{
			Height.SetValue(transform.position.y);
		}

		private void FixedUpdate()
		{
			if (!m_IsColliding)
			{
				LastVelocity = m_Body.velocity;
			}	
		}

		public void CollectSpark()
		{
			float currentCharge = Charge.GetValue();
			Charge.SetValue(currentCharge + 1.0f);
		}

		private void OnCollisionEnter2D(Collision2D _collision)
		{
			m_IsColliding = true;

			OnCollisionEntered?.Invoke(_collision);
		}

		private void OnCollisionExit2D(Collision2D _collision)
		{
			m_IsColliding = false;
		}
	}
}