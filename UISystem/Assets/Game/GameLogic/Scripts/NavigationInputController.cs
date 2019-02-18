using Shimmer.Common.Variables;
using UnityEngine;

namespace Shimmer.Game.GameLogic
{
	public class NavigationInputController : MonoBehaviour
	{
		public FloatReference PlayerHeight;

		// Use this for initialization
		void Start()
		{
		}

		// Update is called once per frame
		void Update()
		{
			Vector3 pos = gameObject.transform.position;

			if (Input.GetKey("up"))
			{
				pos.y += 0.1f;
			}
			else if (Input.GetKey("down"))
			{
				pos.y -= 0.1f;
			}
			else if (Input.GetKey("left"))
			{
				pos.x -= 0.1f;
			}
			else if (Input.GetKey("right"))
			{
				pos.x += 0.1f;
			}
			gameObject.transform.position = pos;
			PlayerHeight.SetValue(pos.y);
		}
	}
}