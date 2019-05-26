using Shimmer.Common.Actions;
using Shimmer.Game.InputControl;
using UnityEngine;
using UnityEngine.Assertions;

namespace Shimmer.UI.Common
{
	public class GameSetup : MonoBehaviour
	{
		public static GameSetup Instance
		{
			get
			{
				Assert.IsNotNull(s_Instance, "There is no active instance of GameSetup present in the scene");

				return s_Instance;
			}
		}	

		public InputController InputController;

		public ActionList OnSetup;

		private static GameSetup s_Instance = null;

		private void Awake()
		{
			OnSetup.Execute(this);
		}

		private void OnEnable()
		{
			s_Instance = this;
		}

		private void OnDisable()
		{
			s_Instance = null;
		}
	}
}
