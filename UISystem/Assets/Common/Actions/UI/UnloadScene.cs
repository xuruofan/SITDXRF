using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Shimmer.Common.Actions.UI
{
	[Serializable]
	public class UnloadScene : Action
	{
		public string SceneName;
		
		public static string MenuName
		{
			get
			{
				return "UI/Unload Scene";
			}
		}

		public override void Execute(MonoBehaviour _behaviour)
		{
			SceneManager.UnloadSceneAsync(SceneName);
		}
	}

}