using Shimmer.Common.Actions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shimmer.UI.Common
{
	[RequireComponent(typeof(Button))]
	public class ButtonAction : MonoBehaviour
	{
		public ActionList OnButtonClick;

		private Button m_Button;

		private void Awake()
		{
			m_Button = gameObject.GetComponent<Button>();
		}

		private void OnEnable()
		{
			m_Button.onClick.AddListener(OnClick);
		}

		private void OnDisable()
		{
			m_Button.onClick.RemoveListener(OnClick);
		}

		private void OnClick()
		{
			OnButtonClick.Execute();
		}
	}
}