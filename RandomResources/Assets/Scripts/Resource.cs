using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resource : MonoBehaviour
{
  public int value;

  // Test representations
  public Color[] ComponentColors = new Color[5] { Color.green, Color.red, Color.blue, Color.yellow, Color.magenta };
  public Color[] ProductColors = new Color[4] { Color.black, Color.white, Color.cyan, Color.gray };

  // visually sets this to represent this product
  public void SetProductID(int id)
  {
    GetComponentInChildren<Image>().color = ProductColors[id];
  }
  // visually sets this to represent this component
  public void SetComponentID(int id)
  {
    GetComponentInChildren<Image>().color = ComponentColors[id];
  }

}
