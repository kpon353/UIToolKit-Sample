// 参考URL:
// https://forum.unity.com/threads/property-drawers.595369/#post-5118800

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(Object), true, isFallback = true)]
public class DefaultEditor : Editor
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