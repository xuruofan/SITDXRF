using System;
using UnityEditor;
using UnityEngine;

namespace Shimmer.Common.Variables
{
    public class ResettableScriptableObject : ScriptableObject
    {
        private void OnEnable()
        {
            EditorApplication.playModeStateChanged += OnPlayModeStateChangedChanged;
        }

        private void OnPlayModeStateChangedChanged(PlayModeStateChange obj)
        {
            if (obj == PlayModeStateChange.ExitingPlayMode)
            {
                Resources.UnloadAsset(this);
            }
        }
    }
}