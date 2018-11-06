using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Shimmer.Common;

namespace Shimmer.UI.Common
{
	/// <summary>
	/// This class manages the menu in the game like a push-and-pop stack.
	/// </summary>
    [CreateAssetMenu(fileName = "NewUIManager", menuName = "Shimmer/UI/Common/UI Manager")]
	public class UIManager : ScriptableObject
	{
        public List<GameObject> Pages;

        public void GoTo(GameObject pagePrefab)
        {
			PushPage(pagePrefab);
        }

        public void Back()
        {
            if (Pages.Count > 0)
            {
				PopPage();
            }
        }

		private void PushPage(GameObject pagePrefab)
		{
			Assert.IsNotNull(pagePrefab, "Prefab is null!");

			// If the page already exists in the stack, pop all the pages on top of it to avoid cycles
			int foundIndex = Globals.INVALID_INDEX;
			for (int i = 0; i < Pages.Count; i++)
			{
				if (Pages[i].name.StartsWith(pagePrefab.name))
				{
					foundIndex = i;
					break;
				}
			}
			if (foundIndex != Globals.INVALID_INDEX)
			{
				for (int i = Pages.Count - 1; i > foundIndex; i--)
				{
					PopPage();
				}
				var page = Pages[foundIndex].GetComponent<Page>();
				page.EnablePage();
				return;
			}

			// Disable the previous page if there is any
			if (Pages.Count > 0)
			{
				var previousPageObject = Pages[Pages.Count - 1];
				var previousPage = previousPageObject.GetComponent<Page>();
				previousPage.DisablePage();
			}

			// Spawn new page
			var newPageObject = Instantiate(pagePrefab, GameObject.Find("Canvas").transform);
			var newPage = newPageObject.GetComponent<Page>();
			Assert.IsNotNull(newPage, "Object does not contain a Page component!");

			// Enable new page
			newPage.EnablePage();
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
			Pages.Remove(lastPageObject);

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

		public void Reset()
		{
			Pages.Clear();
		}
	}
}