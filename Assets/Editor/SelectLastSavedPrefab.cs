using System;
using UnityEngine;
using UnityEditor;

public class SelectLastSavedPrefab
{
  private const string SavePrefabKey = "save_prefab_key";

  /// <summary>
  /// Prefabの参照のロード
  /// mac: Shift + Option + P
  /// windows: Shift + Alt + P
  /// </summary>
  [MenuItem("SavePrefabPath/LoadAsset #&p")]
  private static void SelectLastSelectPrefab()
  {
    try
    {
      var loadAssetGUID = PlayerPrefs.GetString(SavePrefabKey);
      var assetPath = AssetDatabase.GUIDToAssetPath(loadAssetGUID);
      var targetAssets = AssetDatabase.LoadAssetAtPath<GameObject>(assetPath);
      Selection.activeObject = targetAssets;
    }
    catch (Exception e)
    {
      Debug.LogError(e);
    }
  }

  /// <summary>
  /// Prefabの参照の保存
  /// mac: Shift + Option + L
  /// windows: Shift + Alt + L
  /// </summary>
  [MenuItem("SavePrefabPath/LoadAsset #&l")]
  private static void SaveLastSelectPrefab()
  {
    try
    {
      var selection = Selection.assetGUIDs[0];
      var assetPath = AssetDatabase.GUIDToAssetPath(selection);
      var targetAssets = AssetDatabase.LoadAssetAtPath<GameObject>(assetPath);
      if (targetAssets == null)
      {
        Debug.LogWarning($"{assetPath} is Not GameObject!");
        return;
      }

      PlayerPrefs.SetString(SavePrefabKey, Selection.assetGUIDs[0]);
      PlayerPrefs.Save();
    }
    catch (Exception e)
    {
      Debug.LogError(e);
    }
  }
}
