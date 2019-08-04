using UnityEditor;
using UnityEngine;

namespace Shimmer.Common.Variables
{
    public class ResettableScriptableObject : ScriptableObject
    {
		public bool Reset;

#if UNITY_EDITOR
		private void OnEnable()
        {
			EditorApplication.playModeStateChanged += OnPlayModeStateChangedChanged;
		}

        private void OnPlayModeStateChangedChanged(PlayModeStateChange obj)
        {
            if (Reset && obj == PlayModeStateChange.ExitingPlayMode)
            {
                Resources.UnloadAsset(this);
            }
        }
#endif
	}
}