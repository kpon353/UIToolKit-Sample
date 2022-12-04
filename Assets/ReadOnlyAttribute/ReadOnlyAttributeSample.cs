using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadOnlyAttributeSample : MonoBehaviour
{
  [ReadOnly]
  public int ReadonlyPublicInt;

  [SerializeField, ReadOnly]
  private int ReadOnlyPrivateInt;
}
