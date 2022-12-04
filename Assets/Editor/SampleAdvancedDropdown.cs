using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.IMGUI.Controls;

public class SampleAdvancedDropdown : AdvancedDropdown
{
  public SampleAdvancedDropdown(AdvancedDropdownState state) : base(state)
  {
    var minSize = minimumSize;
    minSize.y = 200;
    minimumSize = minSize;
  }

  protected override AdvancedDropdownItem BuildRoot()
  {
    var root = new AdvancedDropdownItem("Root");

    for (var i = 0; i < 10; i++)
    {
      var item = new AdvancedDropdownItem($"Item {i + 1}");
      for (var j = 0; j < 10; j++)
      {
        item.AddChild(new AdvancedDropdownItem($"Item {i + 1} - {j + 1}"));
      }
      root.AddChild(item);
    }
    return root;
  }

  protected override void ItemSelected(AdvancedDropdownItem item)
  {
    Debug.Log($"Selected: {item.name}");
  }
}
