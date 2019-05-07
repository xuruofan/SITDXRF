using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Shimmer.Common.Actions.UI
{
	[Serializable]
	public class LoadScene : Action
	{
		public string SceneName;
		public LoadSceneMode SceneMode;

		public static string MenuName
		{
			get
			{
				return "UI/Load Scene";
			}
		}

		public override void Execute(MonoBehaviour _behaviour)
		{
			SceneManager.LoadScene(SceneName, SceneMode);
		}
	}

}