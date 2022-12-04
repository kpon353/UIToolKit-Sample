using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

/// <summary>
/// ReadOnlyというAttributeを定義する為のクラス
/// クラス名に"Attribute"を入れる必要がある
/// ex : [SerializeField, ReadOnly]
/// </summary>
public class ReadOnlyAttribute : PropertyAttribute
{

}

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
public class ReadOnlyAttributeDrawer : PropertyDrawer
{
  public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
  {
    EditorGUI.BeginDisabledGroup(true);
    EditorGUI.PropertyField(position, property, label, true);
    EditorGUI.EndDisabledGroup();
  }
}
#endif