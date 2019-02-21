using Shimmer.Common.Variables;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Shimmer.Game.GameLogic
{
	public enum InputPhase
	{
		None, Begin, Hold, End
	}

	public class InputController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
	{
		public IntVariable Phase;
		public Vector2Variable Position;
		
		private void Awake()
		{
			Phase.SetValue((int)InputPhase.None);
		}

		public void OnPointerDown(PointerEventData _eventData)
		{
			Phase.SetValue((int)InputPhase.Begin);
			Position.SetValue(_eventData.position);
		}

		public void OnPointerUp(PointerEventData _eventData)
		{
			Phase.SetValue((int)InputPhase.End);
			Position.SetValue(_eventData.position);
		}

		private void OnMouseDrag()
		{
			if (Phase.GetValue() == (int)InputPhase.Begin)
			{
				Phase.SetValue((int)InputPhase.Hold);
			}
			Position.SetValue(Input.mousePosition);
		}
	}
}