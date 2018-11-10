using UnityEditor;
using UnityEngine;

// IngredientDrawer
namespace Shimmer.Tools
{
	[CustomPropertyDrawer(typeof(Recipe))]
	public class RecipeDrawer : PropertyDrawer
	{
		// Draw the property inside the given rect
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			// Using BeginProperty / EndProperty on the parent property means that
			// prefab override logic works on the entire property.
			EditorGUI.BeginProperty(position, label, property);

			// Draw label
			position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
			EditorGUI.ObjectField(position, GUIContent.none, property.objectReferenceValue, typeof(Recipe), true);

			EditorGUI.EndProperty();
		}
	}
}