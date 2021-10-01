using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Shapes;

public class Resource : MonoBehaviour
{
  static List<Sprite> resourceSprites = new List<Sprite>();
  static List<string> resourceNames = new List<string>();
  static List<Color> resourceColors = new List<Color>();
  static List<int> resourcePrices = new List<int>();

  public int value;

  [SerializeField]
  GameObject filledDisplay, emptyDisplay;

  [SerializeField]
  ShapeRenderer outlineShape, backgroundShape;

  [SerializeField]
  Image icon, unlitIcon;

  static public void ResetResources()
  {
    resourceSprites.Clear();
    resourceNames.Clear();
    resourceColors.Clear();
    resourcePrices.Clear();
  }

  // visually sets this to represent this component
  public void SetComponentID(int id)
  {
    CheckResources(id - 1);
    outlineShape.Color = resourceColors[id - 1];
    backgroundShape.Color = resourceColors[id - 1] * 0.8f;
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
    while (ID >= resourceColors.Count) resourceColors.Add(RandomUtils.GenerateColor());
    while (ID >= resourcePrices.Count) resourcePrices.Add(RandomUtils.GeneratePrice());
  }
}
