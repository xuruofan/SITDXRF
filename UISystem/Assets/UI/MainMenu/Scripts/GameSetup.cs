using Shimmer.Common.Actions;
using UnityEngine;

namespace Shimmer.UI.Common
{
    public class GameSetup : MonoBehaviour
    {
		public ActionList Setup;

		private void Awake()
		{
			Setup.Execute(this);
		}
	}
}
