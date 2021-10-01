using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Shapes;

public class Resource : MonoBehaviour
{
  static List<Sprite> resourceSprites = new List<Sprite>();
  static List<string> resourceNames = new List<string>();

  public int value;

  // Test representations
  public Color[] ComponentColors = new Color[9] { Color.green, Color.red, Color.blue, Color.yellow, Color.magenta, Color.black, Color.white, Color.cyan, Color.gray };

  [SerializeField]
  GameObject filledDisplay, emptyDisplay;

  [SerializeField]
  ShapeRenderer outlineShape, backgroundShape;

  [SerializeField]
  Image icon, unlitIcon;

  // visually sets this to represent this component
  public void SetComponentID(int id)
  {
    outlineShape.Color = ComponentColors[id - 1];
    backgroundShape.Color = ComponentColors[id - 1] * 0.8f;
    CheckResources(id - 1);
    icon.sprite = resourceSprites[id - 1];
    unlitIcon.sprite = resourceSprites[id - 1];
  }

  public static string GetName(int ID)
  {
    CheckResources(ID - 1);
    return resourceNames[ID - 1];
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

  private static void CheckResources(int ID)
  {
    while (ID >= resourceSprites.Count) resourceSprites.Add(RandomUtils.GenerateImage());
    while (ID >= resourceNames.Count) resourceNames.Add(RandomUtils.GenerateName());
  }
}
