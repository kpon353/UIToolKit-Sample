using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class OpenScene : EditorWindow
{
  private string[] m_scenePaths;

  [MenuItem("Window/OpenScene")]
  public static void OpenWindow()
  {
    EditorWindow.GetWindow<OpenScene>();
  }

  private void OnEnable()
  {
    string[] guids = AssetDatabase.FindAssets("t:Scene");
    m_scenePaths = new string[guids.Length];
    for (var i = 0; i < guids.Length; i++)
    {
      m_scenePaths[i] = AssetDatabase.GUIDToAssetPath(guids[i]);
    }
    Repaint();
  }

  private void OnGUI()
  {
    foreach (var scenePath in m_scenePaths)
    {
      var startwordPosition = scenePath.LastIndexOf("/") + 1;
      if (GUILayout.Button(scenePath.Substring(startwordPosition, scenePath.Length - startwordPosition - 6) + "シーン"))
      {
        EditorSceneManager.OpenScene(scenePath);
      }
    }
  }
}
