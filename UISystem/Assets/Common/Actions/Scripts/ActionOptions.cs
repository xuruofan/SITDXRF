﻿using Shimmer.Tools;
using System;

namespace Shimmer.Common.Actions
{
	[Serializable]
	public class ActionOptions : Options<Action>
	{
		// Actions
		public Actions.Invoke[] m_Actions_Invoke;
		public Actions.Delay[] m_Actions_Delay;
		public Actions.ActivateGameObject[] m_Actions_ActivateGameObject;
		public Actions.EnableComponent[] m_Actions_EnableComponent;
		public Actions.Pause[] m_Actions_Pause;
		// Variable
		public Variables.SetInt[] m_Variables_SetInt;
		public Variables.SetBool[] m_Variables_SetBool;
		// Text
		public Texts.SetText[] m_Texts_SetText;
		public Texts.SetString[] m_Texts_SetString;
		public Texts.PrintLog[] m_Texts_PrintLog;
		// Visuals
		public Visuals.Flip[] m_Visuals_Flip;
		public Visuals.SetAnimationTrigger[] m_Visuals_SetAnimationTrigger;
		public Visuals.SetAnimationBool[] m_Visuals_SetAnimationBool;
		public Visuals.SetImageFill[] m_Visuals_SetImageFill;
		//UI
		public UI.GoTo[] m_UI_GoTo;
		public UI.GoBack[] m_UI_GoBack;
		public UI.LoadScene[] m_UI_LoadScene;
		public UI.UnloadScene[] m_UI_UnloadScene;
	}
}