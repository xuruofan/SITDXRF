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
		public delegate void OnCollisionExitEvent(Collision2D _collision);

		public InputController InputController;
		
		public FloatReference Charge;
		public FloatVariable Height;
		public bool IsFacingRight = true;

		[SerializeField]
		private FloatReference MaxXSpeed;
		[SerializeField]
		private FloatReference MaxYSpeed;

		public OnCollisionEnterEvent OnCollisionEntered;
		public OnCollisionExitEvent OnCollisionExited;
		
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

		private void Update()
		{
			Height.SetValue(transform.position.y);	
		}

		public void CollectSpark()
		{
			float currentCharge = Charge.GetValue();
			Charge.SetValue(currentCharge + 1.0f);
		}

		private void OnCollisionEnter2D(Collision2D _collision)
		{
			OnCollisionEntered?.Invoke(_collision);
		}

		private void OnCollisionExit2D(Collision2D _collision)
		{
			OnCollisionExited?.Invoke(_collision);
		}
	}
}