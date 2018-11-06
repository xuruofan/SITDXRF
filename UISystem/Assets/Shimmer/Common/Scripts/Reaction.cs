using UnityEngine;
using UnityEngine.Events;

namespace Shimmer.Common
{
	public class Reaction : MonoBehaviour
	{
		public Condition Condition;
		public UnityEvent Action;
	}
}