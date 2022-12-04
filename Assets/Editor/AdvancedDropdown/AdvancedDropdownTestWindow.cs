using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.IMGUI.Controls;

public class AdvancedDropdownTestWindow : EditorWindow
{
  private void OnGUI()
  {
    var buttonLabel = new GUIContent("Show");
    var buttonStyle = EditorStyles.toolbarButton;
    var buttonRect = GUILayoutUtility.GetRect(buttonLabel, buttonStyle);
    if (GUI.Button(buttonRect, buttonLabel, buttonStyle))
    {
      // ドロップダウンを表示
      var dropdown = new SampleAdvancedDropdown(new AdvancedDropdownState());
      dropdown.Show(buttonRect);
    }
  }

  [MenuItem("Example/Advanced Dropdown")]
  public static void Open()
  {
    GetWindow<AdvancedDropdownTestWindow>();
  }
}
