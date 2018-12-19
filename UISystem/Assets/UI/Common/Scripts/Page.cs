using Shimmer.Common.Actions;
using UnityEngine;

namespace Shimmer.UI.Common
{
    public class Page : MonoBehaviour
    {
        public UIManager Manager;
		public float DelayDisableInSeconds;
		public ActionList OnEnabled;
		public ActionList OnDisabled;

        private void Start()
        {
			Manager.RegisterPage(this);
        }

		public void EnablePage()
		{
			gameObject.SetActive(true);
			OnEnabled.Execute();
		}

		public void DisablePage()
		{
			OnDisabled.Execute();
			Invoke("DelayDisable", DelayDisableInSeconds);	
		}

		private void DelayDisable()
		{
			gameObject.SetActive(false);
		}
	}
}
