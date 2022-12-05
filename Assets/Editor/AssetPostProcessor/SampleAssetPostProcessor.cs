using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SampleAssetPostProcessor : AssetPostprocessor
{
  private static void OnPostprocessAllAssets(string[] importedAssetPaths, string[] deletedAssetPaths, string[] movedAssetPaths, string[] movedFromAssetPaths)
  {
    // あらゆるアセットのインポート処理の後に呼ばれる
    // AssetDatabase.LoadAssetAtPath()でアセットを取得できる
  }

  /// <summary>
  /// PostProcessorが複数存在する場合の処理順を決める値、昇順で処理される
  /// </summary>
  /// <returns></returns>
  public override int GetPostprocessOrder()
  {
    return 1;
  }

  /// <summary>
  /// バージョンが変わるとそのPostprocessorの処理が全てのアセットに対して走る
  /// </summary>
  /// <returns></returns>
  public override uint GetVersion()
  {
    return 1;
  }

  private void OnPreprocessTexture()
  {
    LogAssetPath();

    // TextureImporterの設定項目を書き換える
    var importer = assetImporter as TextureImporter;
    importer.alphaIsTransparency = true;
  }

  private void OnPostprocessTexture(Texture2D tex)
  {

  }

  private void LogAssetPath()
  {
    // 取れる
    Debug.Log(AssetDatabase.AssetPathToGUID(assetPath));
    // 初回インポート時は取れない
    Debug.Log(AssetDatabase.LoadAssetAtPath<Texture>(assetPath));
  }
}
