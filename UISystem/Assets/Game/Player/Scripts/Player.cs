using Shimmer.Common.Variables;
using UnityEngine;
using UnityEngine.Assertions;

namespace Shimmer.Game.Player
{
	public class Player : MonoBehaviour
	{
		public delegate void OnCollisionEnterEvent(Collision2D _collision);
		public delegate void OnCollisionExitEvent(Collision2D _collision);

		public BoolVariable Dead;

		[SerializeField]
		public GameObject Visual;

		public float Charge
		{
			get { return m_Charge; }
			private set
			{
				m_Charge = value;

				ChargeValue.SetValue(value);
			}
		}

		public float Lives
		{
			get { return m_Lives; }
			private set
			{
				m_Lives = value;
				LifeValue.SetValue(value);
			}
		}

		public float Height
		{
			get { return m_Height; }
			private set
			{
				m_Height = value;

				HeightValue.SetValue(value);

				if (value > MaxHeight)
				{
					MaxHeight = value;
				}
			}
		}

		public float MaxHeight
		{
			get { return m_MaxHeight; }
			private set
			{
				m_MaxHeight = value;

				MaxHeightValue.SetValue(value);
			}
		}

		private float m_Charge;
		private float m_Lives;
		private float m_Height;
		private float m_MaxHeight;

		public FloatReference ChargeValue;
		public FloatReference LifeValue;
		public FloatVariable HeightValue;
		public FloatVariable MaxHeightValue;

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
		private bool m_IsRecharging = false;

		[SerializeField]
		private FloatReference MaxXSpeed;
		[SerializeField]
		private FloatReference MaxYSpeed;
		public FloatReference MaxCharge;
		public FloatReference DefaultCharge;
		public FloatReference RechargeSpeed;
		public FloatReference DefaultLives;

		public OnCollisionEnterEvent OnCollisionEntered;
		public OnCollisionExitEvent OnCollisionExited;

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

			Charge = DefaultCharge.GetValue();
			Lives = DefaultLives.GetValue();
			MaxHeight = 0;

			Dead.SetValue(false);
		}

		private void Update()
		{
			Height = transform.position.y;

			if (m_IsRecharging && Charge < DefaultCharge.GetValue())
			{
				Charge += RechargeSpeed.GetValue() * Time.deltaTime;
			}
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
			float amount = Charge + 1.0f;

			Charge = Mathf.Clamp(amount, 0, MaxCharge.GetValue());
		}

		public void SpendCharge(float _amount)
		{
			float amount = Charge - _amount;

			Charge = Mathf.Clamp(amount, 0, MaxCharge.GetValue());
		}

		public void Recharge(bool _start)
		{
			m_IsRecharging = _start;
		}

		public void Kill()
		{
			Lives = 0;

			Dead.SetValue(true);
		}

		private void OnCollisionEnter2D(Collision2D _collision)
		{
			m_IsColliding = true;

			OnCollisionEntered?.Invoke(_collision);
		}

		private void OnCollisionExit2D(Collision2D _collision)
		{
			OnCollisionExited?.Invoke(_collision);

			m_IsColliding = false;
		}
	}
}