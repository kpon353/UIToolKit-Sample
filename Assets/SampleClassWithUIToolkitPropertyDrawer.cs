#if UNITY_EDITOR
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UIElements;

[CustomPropertyDrawer(typeof(SampleClassWithUIToolKit))]
public class SampleClassWithUIToolkitPropertyDrawer : PropertyDrawer
{
  public override VisualElement CreatePropertyGUI(SerializedProperty property)
  {
    return new PropertyField(property)
    {
      // 色を赤くしてみる
      style = { color = new StyleColor(Color.red) },
    };
  }
}
#endif