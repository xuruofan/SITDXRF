using System;
using UnityEditor;
using UnityEngine;

namespace Shimmer.Tools.Editor
{
    public static class EditorHelper
    {
        public static readonly float kIndentPerLevel = 15; // == EditorGUI.kIndentPerLevel which is private

        public static void ApplyModifiedProperties(SerializedObject _object)
        {
            // SetDirty is still needed when editing ScriptableObjects outside a Scene
            EditorUtility.SetDirty(_object.targetObject);
            _object.ApplyModifiedProperties();
        }

        public static void ResetPropertyValue(SerializedProperty _property, Type _type)
        {
            switch (_property.type)
            {
                case "int":
                    _property.intValue = 0;
                    return;
                case "long":
                    _property.longValue = 0;
                    return;
                case "bool":
                    _property.boolValue = false;
                    return;
                case "float":
                    _property.floatValue = 0f;
                    return;
                case "double":
                    _property.doubleValue = 0.0;
                    return;
                case "string":
                    _property.stringValue = "";
                    return;
                case "Color":
                    _property.colorValue = Color.white;
                    return;
                case "AnimationCurve":
                    _property.animationCurveValue = new AnimationCurve();
                    return;
                case "Vector2":
                    _property.vector2Value = Vector2.zero;
                    return;
                case "Vector3":
                    _property.vector3Value = Vector3.zero;
                    return;
                case "Vector4":
                    _property.vector4Value = Vector4.zero;
                    return;
                case "Vector2Int":
                    _property.vector2IntValue = Vector2Int.zero;
                    return;
                case "Vector3Int":
                    _property.vector3IntValue = Vector3Int.zero;
                    return;
                case "Quaternion":
                    _property.quaternionValue = Quaternion.identity;
                    return;
                case "Rect":
                    _property.rectValue = new Rect();
                    return;
                case "RectInt":
                    _property.rectIntValue = new RectInt();
                    return;
                case "Bounds":
                    _property.boundsValue = new Bounds();
                    return;
                case "Enum":
                    _property.enumValueIndex = 0;
                    return;
                default:
                    if (_property.isArray)
                    {
                        _property.arraySize = 0;
                        return;
                    }
                    if (_property.type.StartsWith("PPtr"))
                    {
                        _property.objectReferenceValue = null;
                        return;
                    }

                    if (_type != null)
                    {
                        foreach (var field in _type.GetFields())
                        {
                            var prop = _property.FindPropertyRelative(field.Name);
                            if (prop != null)
                            {
                                ResetPropertyValue(prop, field.FieldType);
                            }
                        }
                    }
                    break;
            }
        }
    }
}