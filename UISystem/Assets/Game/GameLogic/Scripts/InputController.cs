using Shimmer.Common.Variables;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Shimmer.Game.GameLogic
{
	public class InputController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
	{
		public delegate void OnPointerHoldBeginEvent(Vector2 _position);
		public delegate void OnPointerHoldEndEvent(Vector2 _position);

		public float OnHoldThreshold;

		public OnPointerHoldBeginEvent OnPointerHoldBegin;
		public OnPointerHoldEndEvent OnPointerHoldEnd;

		private float m_PressedTime;
		private bool m_Pressed;
		private Vector2 m_Position;

		private void Awake()
		{
			m_PressedTime = 0;	
		}

		private void Update()
		{
			if (m_Pressed)
			{
				m_PressedTime += Time.deltaTime;

				if (m_PressedTime > OnHoldThreshold)
				{
					OnPointerHoldEnd?.Invoke(m_Position);
				}
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			m_Pressed = true;
			m_PressedTime = 0;		
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			m_Pressed = false;
		}
	}
}