using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

namespace Shimmer.Tools.Editor
{
	[CustomPropertyDrawer(typeof(OptionsBase), true)]
	public class OptionsPropertyDrawer : PropertyDrawer
	{
		private FieldInfo[] m_fields;
		private Type[] m_itemTypes;
		private GUIContent[] m_itemLabels;
		private SerializedProperty[] m_properties;
		private int m_lastSelected = 1;

		private Type GetItemType(FieldInfo _field)
		{
			var type = _field.FieldType;
			if (type.IsArray)
			{
				return type.GetElementType();
			}
			return type;
		}

		private SerializedProperty GetProperty(SerializedProperty _property, int _index)
		{
			var property = m_properties[_index];
			if (property == null)
			{
				var fieldIndex = _index - 1;
				property = _property.FindPropertyRelative(m_fields[fieldIndex].Name);

				m_properties[_index] = property;
			}
			return property;
		}

		private GUIContent MakeItem(Type _type)
		{
			var menuName = _type.GetProperty("MenuName");
			Assert.IsNotNull(menuName, $"{_type.ToString()} did not specify a menu name.");

			return new GUIContent(menuName.GetValue(null) as string);
		}

		private void Setup()
		{
			if (m_fields == null)
			{
				// Get all the fields of this Any field
				var type = GetItemType(fieldInfo);
				m_fields = type.GetFields();

				m_itemTypes = new Type[m_fields.Length + 1];
				m_itemTypes[0] = null;  // The first item in the list is none

				m_itemLabels = new GUIContent[m_fields.Length + 1];
				m_itemLabels[0] = new GUIContent("None");

				// Set type and make the GUI label for each item
				for (var i = 0; i < m_fields.Length; i++)
				{
					m_itemTypes[i + 1] = GetItemType(m_fields[i]);
					m_itemLabels[i + 1] = MakeItem(m_itemTypes[i + 1]);
				}

				m_properties = new SerializedProperty[m_fields.Length + 1];
			}

			// Reset properties
			for (int i = 0; i < m_properties.Length; i++)
			{
				m_properties[i] = null;
			}
		}

		private int FindSelected(SerializedProperty _property)
		{
			if (GetProperty(_property, m_lastSelected).arraySize > 0)
			{
				return m_lastSelected;
			}

			for (int i = 1; i < m_properties.Length; i++)
			{
				if (GetProperty(_property, i).arraySize > 0)
				{
					m_lastSelected = i;
					return i;
				}
			}

			return 0;
		}

		public override void OnGUI(Rect _position, SerializedProperty _property, GUIContent _label)
		{
			_label = EditorGUI.BeginProperty(_position, _label, _property);
			EditorGUI.BeginChangeCheck();

			Setup();

			var index = FindSelected(_property);

			var popupPosition = _position;
			popupPosition.height = EditorGUIUtility.singleLineHeight;

			int newIndex = EditorGUI.Popup(popupPosition, _label, index, m_itemLabels);

			if (newIndex != index)
			{
				if (newIndex != 0)
				{
					var selectedProperty = GetProperty(_property, newIndex);
					selectedProperty.arraySize = 1;
					var item = selectedProperty.GetArrayElementAtIndex(0);
					EditorHelper.ResetPropertyValue(item, m_itemTypes[newIndex]);
					item.isExpanded = true;
				}

				if (index != 0)
				{
					var prevProperty = GetProperty(_property, index);
					prevProperty.arraySize = 0;
				}
			}

			if (newIndex != 0)
			{
				var item = GetProperty(_property, newIndex).GetArrayElementAtIndex(0);
				EditorGUI.PropertyField(_position, item, GUIContent.none, true);
			}

			if (EditorGUI.EndChangeCheck())
			{
				EditorHelper.ApplyModifiedProperties(_property.serializedObject);
			}
			EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight(SerializedProperty _property, GUIContent _label)
		{
			Setup();

			var index = FindSelected(_property);
			if (index > 0)
			{
				var item = GetProperty(_property, index).GetArrayElementAtIndex(0);
				return EditorGUI.GetPropertyHeight(item, true);
			}

			return EditorGUIUtility.singleLineHeight;
		}
	}
}