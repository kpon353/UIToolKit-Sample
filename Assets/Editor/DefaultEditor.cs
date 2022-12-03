// 参考URL:
// https://forum.unity.com/threads/property-drawers.595369/#post-5118800

#if UNITY_EDITOR
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UIElements;

[CustomEditor(typeof(Object), true, isFallback = true)]
public class DefaultEditor : Editor
{
  public static VisualElement CreateScriptReadonlyField(SerializedProperty property)
  {
    var propertyField = new VisualElement { name = $"PropertyField:{property.propertyPath}" };
    var objectField = new ObjectField("Script") { name = "unity-input-m_Script" };
    objectField.BindProperty(property);
    // スペースキーを押してもスクリプトを選択するウィンドウを表示しないようにする
    objectField.focusable = false;
    propertyField.Add(objectField);
    propertyField.Q(null, "unity-object-field__selector")?.SetEnabled(false);
    propertyField.Q(null, "unity-base-field__label")?.AddToClassList("unity-disabled");
    propertyField.Q(null, "unity-base-field__input")?.AddToClassList("unity-disabled");
    return propertyField;
  }

  public override VisualElement CreateInspectorGUI()
  {
    var container = new VisualElement();
    var iterator = serializedObject.GetIterator();

    if (iterator.NextVisible(true))
    {
      do
      {
        var serializedProperty = iterator.Copy();
        VisualElement propertyField;

        if (iterator.propertyPath == "m_Script" && serializedObject.targetObject != null)
        {
          propertyField = CreateScriptReadonlyField(serializedProperty);
        }
        else
        {
          propertyField = new PropertyField(iterator.Copy()) { name = "PropertyField:" + iterator.propertyPath };
        }

        container.Add(propertyField);
      }
      while (iterator.NextVisible(false));
    }

    // IMGUI同様のInspectorを実装
    InspectorElement.FillDefaultInspector(container, serializedObject, this);

    return container;
  }
}
#endif