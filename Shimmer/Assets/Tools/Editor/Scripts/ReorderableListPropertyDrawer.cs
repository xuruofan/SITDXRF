using System;
using System.Reflection;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using InternalList = UnityEditorInternal.ReorderableList;

namespace Shimmer.Tools.Editor
{
	[CustomPropertyDrawer(typeof(ReorderableListBase), true)]
	public class ReorderableListPropertyDrawer : PropertyDrawer
	{
		public InternalList m_List;
		public Type m_ItemType;
		public SerializedProperty m_ItemsProperty;
		public GUIContent m_Label;

		static readonly string itemsPropertyName = "Items";

		private InternalList GetList(SerializedProperty _property)
		{
			m_ItemsProperty = _property.FindPropertyRelative(itemsPropertyName);

			if (m_List == null)
			{
				m_List = MakeList(m_ItemsProperty);
			}
			else
			{
				m_List.serializedProperty = m_ItemsProperty;
			}

			return m_List;
		}

		private InternalList MakeList(SerializedProperty _property)
		{
			var list = new InternalList(_property.serializedObject, _property, true, true, true, true);
			m_ItemType = fieldInfo.FieldType.GetField(itemsPropertyName).FieldType.GetElementType();

			list.drawHeaderCallback = DrawHeaderCallback;
			list.elementHeightCallback = ElementHeightCallback;
			list.drawElementCallback = DrawElementCallback;
			list.onAddCallback = OnAddCallback;

			return list;
		}

		private string MakeTitle(string _title, int _size)
		{
			return $"{_title} ({_size})";
		}

		private void OnAddCallback(InternalList _list)
		{
			var index = _list.serializedProperty.arraySize;
			_list.serializedProperty.arraySize++;
			_list.index = _list.serializedProperty.arraySize - 1;
		}

		private void DrawElementCallback(Rect _rect, int _index, bool _isActive, bool _isFocused)
		{
			if (_index >= m_List.serializedProperty.arraySize)
			{
				return;
			}

			EditorGUI.indentLevel++;

			var element = m_List.serializedProperty.GetArrayElementAtIndex(_index);
			_rect.yMin += EditorGUIUtility.standardVerticalSpacing;
			_rect.yMax += EditorGUIUtility.standardVerticalSpacing;
			_rect.xMin += 10;

			EditorGUI.PropertyField(_rect, element, GUIContent.none, true);

			EditorGUI.indentLevel--;
		}

		private float ElementHeightCallback(int _index)
		{
			if (_index >= m_List.serializedProperty.arraySize)
			{
				return 0f;
			}

			var element = m_List.serializedProperty.GetArrayElementAtIndex(_index);
			var height = EditorGUI.GetPropertyHeight(element, GUIContent.none);
			height += EditorGUIUtility.standardVerticalSpacing * 2;

			return height;
		}

		private void DrawHeaderCallback(Rect _rect)
		{
			var label = m_Label;
			label.text = MakeTitle(label.text, m_ItemsProperty.arraySize);
			EditorGUI.LabelField(_rect, label);
		}

		public override void OnGUI(Rect _position, SerializedProperty _property, GUIContent _label)
		{
			EditorGUI.BeginProperty(_position, _label, _property);
			m_Label = new GUIContent(_property.name);	// using _property.name as _label somehow changes to "Operator" for ConditonList

			EditorGUI.BeginChangeCheck();

			var prop = _property.Copy();
			var end = _property.GetEndProperty();
			// Display the "Items" field at the end

			if (prop.NextVisible(true))
			{
				do
				{
					if (SerializedProperty.EqualContents(prop, end))
					{
						break;
					}
					if (prop.name == itemsPropertyName)
					{
						continue;
					}
					else
					{
						var propHeight = EditorGUI.GetPropertyHeight(prop, true);
						var propPosition = _position;
						propPosition.height = propHeight;

						_position.yMin += propHeight;
						_position.yMin += EditorGUIUtility.standardVerticalSpacing;

						EditorGUI.PropertyField(propPosition, prop, true);
					}
				} while (prop.NextVisible(false));
			}

			var list = GetList(_property);
			list.DoList(_position);
			if (EditorGUI.EndChangeCheck())
			{
				EditorHelper.ApplyModifiedProperties(_property.serializedObject);
			}
			EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight(SerializedProperty _property, GUIContent _label)
		{
			var list = GetList(_property);
			var height = list.GetHeight();

			var prop = _property.Copy();
			var end = _property.GetEndProperty();

			if (prop.NextVisible(true))
			{
				do
				{
					if (SerializedProperty.EqualContents(prop, end))
					{
						break;
					}
					if (prop.name == itemsPropertyName)
					{
						continue;
					}
					else
					{
						height += EditorGUI.GetPropertyHeight(prop, true);
						height += EditorGUIUtility.standardVerticalSpacing;
					}
				} while (prop.NextVisible(false));
			}

			return height;
		}
	}
}