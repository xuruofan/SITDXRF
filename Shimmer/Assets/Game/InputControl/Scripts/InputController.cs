using Shimmer.Common.Variables;
using UnityEngine;

namespace Shimmer.Game.InputControl
{
	public enum EInputPhase
	{
		None, Begin, Hold, End
	}

	public class InputController : MonoBehaviour
	{
		public IntVariable Phase;
		public Vector2Variable Position;

		public Vector2 WorldPosition
		{
			get { return m_Camera.ScreenToWorldPoint(Position.GetValue()); }
		}

		[SerializeField]
		private Camera m_Camera;

		private void Awake()
		{
			Phase.SetValue((int)EInputPhase.None);
		}

		private void Update()
		{
			bool isDown = Input.GetMouseButton(0);
			EInputPhase currentPhase = (EInputPhase)Phase.GetValue();
			EInputPhase newPhase = EInputPhase.None;

			if (isDown)
			{	
				switch (currentPhase)
				{
					case EInputPhase.None:
						newPhase = EInputPhase.Begin;
						break;
					case EInputPhase.Begin:
						newPhase = EInputPhase.Hold;
						break;
					case EInputPhase.Hold:
						newPhase = EInputPhase.Hold;
						break;
				}

				Vector2 oldPosition = Position.GetValue();
				Vector2 newPosition = Input.mousePosition;
				newPosition.y = m_Camera.pixelHeight;

				if (oldPosition != newPosition)
				{
					Position.SetValue(newPosition);
				}
			}
			else
			{
				switch (currentPhase)
				{
					case EInputPhase.Hold:
						newPhase = EInputPhase.End;
						break;
					case EInputPhase.End:
						newPhase = EInputPhase.None;
						break;
				}
			}

			if (currentPhase != newPhase)
			{
				Phase.SetValue((int)newPhase);
				Debug.Log($"Input phase: {newPhase}");
			}
		}
	}
}