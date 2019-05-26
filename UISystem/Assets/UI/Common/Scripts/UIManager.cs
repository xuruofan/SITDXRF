using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Shimmer.Common.Variables;

namespace Shimmer.UI.Common
{
    /// <summary>
    /// This class manages the menu in the game like a push-and-pop stack.
    /// </summary>
    [CreateAssetMenu(fileName = "NewUIManager", menuName = "Shimmer/UI/Common/UI Manager")]
    public class UIManager : ResettableScriptableObject
    {
        [Header("Setup")]
        public bool AllowEmpty;
        public List<GameObject> Pages;

        public void GoTo(GameObject _pagePrefab)
        {
            PushPage(_pagePrefab);
        }

        public void Back()
        {
            int limit = AllowEmpty ? 0 : 1;
            if (Pages.Count > limit)
            {
                PopPage();
            }
        }

        public void RegisterPage(Page _page)
        {
            if (Pages.Count == 0)
            {
                _page.EnablePage();
            }
            if (!Pages.Contains(_page.gameObject))
            {
                Pages.Add(_page.gameObject);
            }
        }

        private void PushPage(GameObject _pagePrefab)
        {
            Assert.IsNotNull(_pagePrefab, "Prefab is null!");

            // Disable the previous page if there is any
            if (Pages.Count > 0)
            {
                var previousPageObject = Pages[Pages.Count - 1];
                var previousPage = previousPageObject.GetComponent<Page>();
                previousPage.DisablePage();
            }

			// If the page already exists in the stack, pop all the pages on top of it to avoid cycles
			int foundIndex = -1;
			for (int i = 0; i < Pages.Count; i++)
			{
				if (Pages[i].name.StartsWith(_pagePrefab.name))
				{
					foundIndex = i;
					break;
				}
			}
			if (foundIndex != -1)
			{
				for (int i = Pages.Count - 1; i > foundIndex; i--)
				{
					var previousPage = Pages[i].GetComponent<Page>();
					GameObject.Destroy(Pages[i], previousPage.DelayDisableInSeconds);
					Pages.RemoveAt(Pages.Count - 1);
				}

				var page = Pages[foundIndex].GetComponent<Page>();
				page.EnablePage();
				return;
			}

			// Spawn new page
			var newPageObject = Instantiate(_pagePrefab, GameObject.Find("Canvas").transform);
            var newPage = newPageObject.GetComponent<Page>();
            Assert.IsNotNull(newPage, "Object does not contain a Page component!");

            // Enable new page
            newPage.EnablePage();
            RegisterPage(newPage);
        }

        /// <summary>
        /// Pop the last(current) page
        /// </summary>
        private void PopPage()
        {
            if (Pages.Count == 0)
            {
                return;
            }

            // Disable the current page
            var lastPageObject = Pages[Pages.Count - 1];
            var lastPage = lastPageObject.GetComponent<Page>();
            lastPage.DisablePage();
            Pages.RemoveAt(Pages.Count - 1);

            // Enable the page before
            if (Pages.Count > 0)
            {
                var previousPageObject = Pages[Pages.Count - 1];
                var previousPage = previousPageObject.GetComponent<Page>();
                previousPage.EnablePage();
            }

            // Destroy the page being popped
            GameObject.Destroy(lastPageObject, lastPage.DelayDisableInSeconds);
        }
    }
}