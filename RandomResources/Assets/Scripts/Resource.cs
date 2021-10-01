using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Shapes;

public class Resource : MonoBehaviour
{
  public int value;

  // Test representations
  public Color[] ComponentColors = new Color[9] { Color.green, Color.red, Color.blue, Color.yellow, Color.magenta, Color.black, Color.white, Color.cyan, Color.gray };

  [SerializeField]
  GameObject filledDisplay, emptyDisplay;

  [SerializeField]
  ShapeRenderer outlineShape, backgroundShape;

  // visually sets this to represent this component
  public void SetComponentID(int id)
  {
    outlineShape.Color = ComponentColors[id - 1];
    backgroundShape.Color = ComponentColors[id - 1] * 0.8f;
  }

  public void DisplayEmpty()
  {
    filledDisplay.SetActive(false);
    emptyDisplay.SetActive(true);
  }

  public void DisplayFilled()
  {
    filledDisplay.SetActive(true);
    emptyDisplay.SetActive(false);
  }
}
