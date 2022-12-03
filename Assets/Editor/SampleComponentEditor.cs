#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UIElements;

[CustomEditor(typeof(SampleComponent))]
public class SampleComponentEditor : Editor
{
  public override VisualElement CreateInspectorGUI()
  {
    var container = new VisualElement();

    // IMGUI同様のInspectorを実装
    InspectorElement.FillDefaultInspector(container, serializedObject, this);

    return container;
  }
}
#endif