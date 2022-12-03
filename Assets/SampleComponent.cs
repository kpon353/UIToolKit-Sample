using System;
using UnityEngine;

public class SampleComponent : MonoBehaviour
{
  public SampleClassWithIMGUI _sampleClassWithIMGUI;
  public SampleClassWithUIToolKit _sampleClassWithUIToolKit;
}

[Serializable]
public class SampleClassWithIMGUI
{
  public bool _isUIToolKit = false;
}

[Serializable]
public class SampleClassWithUIToolKit
{
  public bool _isUItoolKit = true;
}