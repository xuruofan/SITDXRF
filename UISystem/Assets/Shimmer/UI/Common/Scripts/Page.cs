using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shimmer.UI.Common
{
    public class Page : MonoBehaviour
    {
        public UIManager Manager;

        private void Start()
        {
            
        }

		public void EnablePage()
		{
			gameObject.SetActive(true);
		}

		public void DisablePage()
		{
			gameObject.SetActive(false);
		}

		private void OnApplicationQuit()
		{
			Manager.Reset();
		}
	}
}
