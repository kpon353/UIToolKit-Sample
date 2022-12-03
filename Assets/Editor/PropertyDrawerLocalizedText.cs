#if UNITY_EDITOR
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

[CustomPropertyDrawer(typeof(LocalizedText))]
public class PropertyDrawerLocalizedText : PropertyDrawer
{
  public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
  {
    // 現在格納されているキーデータを元に、ポップアップに必要なデータを取得
    var keys = TextMaster.Instance.Data.Keys.ToArray();
    var textKeyProperty = property.FindPropertyRelative("m_textKey");    // カスタムしているプロパティが持つ"m_textKey"変数のSerializedPropertyを取得する
    var previousIndex = Array.IndexOf(keys, textKeyProperty.stringValue);

    // ポップアップを表示
    var selectedIndex = EditorGUI.Popup(position, previousIndex, TextMaster.Instance.Data.Values.ToArray());

    // ポップアップで値を変えていれば、キーを取得してシリアライズ情報を更新
    if (selectedIndex != previousIndex)
    {
      textKeyProperty.stringValue = keys[selectedIndex];

      // 修正があったらシリアライズしてあるオブジェクトに変更を反映
      textKeyProperty.serializedObject.ApplyModifiedProperties();   // これがないとデータが更新されない
    }
  }
}
#endif