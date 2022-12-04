using UnityEngine;
using UnityEditor;

public class SampleNotificationWindow : EditorWindow
{
  private const float FadeoutWait = 10.5f;
  private int _showCount;

  private void OnGUI()
  {
    if (GUILayout.Button("ShowNotification"))
    {
      ShowNotification(new GUIContent($"Notification {_showCount}"), FadeoutWait);
      _showCount++;
    }

    if (GUILayout.Button("Remove Notification"))
    {
      RemoveNotification();
    }
  }

  [MenuItem("Window/SampleNotificationWindow")]
  private static void Window()
  {
    var window = GetWindow<SampleNotificationWindow>();
    window.Show();
  }
}
