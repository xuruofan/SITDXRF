using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Shimmer.UI.Common
{
    public class Page : MonoBehaviour
    {
        public UIManager Manager;
		public UnityEvent OnEnabled;
		public UnityEvent OnDisabled;
		public float DelayDisableInSeconds;

        private void Start()
        {
        }

		public void EnablePage()
		{
			gameObject.SetActive(true);
			OnEnabled.Invoke();
		}

		public void DisablePage()
		{
			OnDisabled.Invoke();
			Invoke("DelayDisable", DelayDisableInSeconds);	
		}

		private void DelayDisable()
		{
			gameObject.SetActive(false);
		}

		private void OnApplicationQuit()
		{
			Manager.Reset();
		}
	}
}
