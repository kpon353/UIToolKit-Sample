using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextView : MonoBehaviour
{
  [SerializeField] private LocalizedText _text;

  private void Start()
  {
    GetComponent<Text>().text = _text.Value;
  }
}

/// <summary>
/// ローカライズされたテキストデータ
/// </summary>
[Serializable]
public class LocalizedText
{
  // マスターから読み込むのに使うキー
  [SerializeField] private string m_textKey;
  // Viewで使うテキストデータ
  public string Value => TextMaster.Instance.GetText(m_textKey);
}

/// <summary>
/// 仮想テキストマスター。言語設定に合わせてテキストのマスターデータを読み込んで使う。
/// </summary>
public class TextMaster
{
  private static TextMaster m_instance = null;
  public static TextMaster Instance => m_instance ?? (m_instance = new TextMaster());

  public readonly Dictionary<string, string> Data = new Dictionary<string, string>();

  public TextMaster()
  {
    // TODO: 言語設定に合わせたテキストマスターを取得する
    Data = new Dictionary<string, string>()
    {
      { "japanese", "ありがとう" },
      { "english", "Thank you" },
      { "chinese", "謝謝" },
    };
  }

  public string GetText(string key) => Data[key];
}