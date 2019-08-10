using Shimmer.Common.Variables;
using Shimmer.Tools.Editor;
using UnityEditor;
using UnityEngine;

namespace Shimmer.Common.Editor
{
	[CustomPropertyDrawer(typeof(Reference), true)]
	public class ReferencePropertyDrawer : PropertyDrawer
	{
		static private GUIStyle m_Style = new GUIStyle(GUI.skin.GetStyle("PaneOptions"))
		{
			imagePosition = ImagePosition.ImageOnly
		};

		SerializedProperty m_Selection;
		SerializedProperty m_Constant;
		SerializedProperty m_Variable;

		private void Setup(SerializedProperty _property)
		{
			m_Selection = _property.FindPropertyRelative("Selection");
			m_Constant = _property.FindPropertyRelative("Constant");
			m_Variable = _property.FindPropertyRelative("Variable");
		}

		public override void OnGUI(Rect _position, SerializedProperty _property, GUIContent _label)
		{
			var label = EditorGUI.BeginProperty(_position, _label, _property);
			EditorGUI.BeginChangeCheck();

			var contentPos = EditorGUI.PrefixLabel(_position, label);
			int indent = EditorGUI.indentLevel;
			EditorGUI.indentLevel = 0;

			Rect popupPos = contentPos;
			popupPos.yMin += m_Style.margin.top + m_Style.padding.top;
			popupPos.width = m_Style.fixedWidth + m_Style.margin.right;
			popupPos.height = EditorGUIUtility.singleLineHeight;
			contentPos.xMin = popupPos.xMax;

			Setup(_property);

			var previousSelection = (ReferenceSelection)m_Selection.enumValueIndex;
			var newSelection = (ReferenceSelection)EditorGUI.EnumPopup(popupPos, previousSelection, m_Style);

			if (newSelection != previousSelection)
			{
				switch (newSelection)
				{
					case ReferenceSelection.Constant:
						EditorHelper.ResetPropertyValue(m_Variable, typeof(UnityEditor.Graphs.Property));
						break;
					case ReferenceSelection.Variable:
						if (m_Constant != null)
						{
							EditorHelper.ResetPropertyValue(m_Constant, null);
						}
						break;
				}
			}

			switch (newSelection)
			{
				case ReferenceSelection.Constant:
					if (m_Constant != null)
					{
						var childIndent = 0;
						if (m_Constant.hasVisibleChildren)
						{
							contentPos.xMin = _position.xMin;
							if (label.text != "")
							{
								childIndent = indent;
								contentPos.yMin += EditorGUIUtility.singleLineHeight;
								contentPos.yMin += EditorGUIUtility.standardVerticalSpacing;
							}
						}
						EditorGUI.indentLevel += childIndent;
						EditorGUI.PropertyField(contentPos, m_Constant, GUIContent.none, true);
						EditorGUI.indentLevel -= childIndent;
					}
					break;
				case ReferenceSelection.Variable:
					EditorGUI.PropertyField(contentPos, m_Variable, GUIContent.none, true);
					break;
			}

			if (EditorGUI.EndChangeCheck())
			{
				m_Selection.enumValueIndex = (int)newSelection;
				EditorHelper.ApplyModifiedProperties(_property.serializedObject);
			}

			EditorGUI.indentLevel = indent;
			EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight(SerializedProperty _property, GUIContent _label)
		{
			Setup(_property);

			switch ((ReferenceSelection)m_Selection.enumValueIndex)
			{
				case ReferenceSelection.Constant:
					if (m_Constant != null)
					{
						var height = EditorGUI.GetPropertyHeight(m_Constant, GUIContent.none, true);
						if (_label.text != "" && m_Constant.hasVisibleChildren)
						{
							height += EditorGUIUtility.singleLineHeight;
							height += EditorGUIUtility.standardVerticalSpacing;
						}
						return height;
					}
					break;
				case ReferenceSelection.Variable:
					return EditorGUI.GetPropertyHeight(m_Variable, GUIContent.none, true);
			}
			return EditorGUIUtility.singleLineHeight;
		}
	}
}