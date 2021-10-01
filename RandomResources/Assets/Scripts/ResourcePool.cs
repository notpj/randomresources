using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ResourcePool : MonoBehaviour
{
  // Test representations
  public Color[] ComponentColors = new Color[5] { Color.green,  Color.red, Color.blue, Color.yellow, Color.magenta };
  public Color[] ProductColors = new Color[4] { Color.black,  Color.white, Color.cyan, Color.gray };
  public enum ResourceType
  {
    Component,
    Product
  }
  
  [SerializeField]
  TextMeshProUGUI quantityDisplay;
  int quantity = 0;
  int value;

  [SerializeField]
  ResourceType type = ResourceType.Component;

  public ResourceType resourceType
  {
    get 
    {
      return type;
    }
  }

  public bool TakeSome(int amount = 1)
  {
    if (quantity - amount >= 0)
    {
      quantity -= amount;
      UpdateDisplay();
      return true;
    }

    return false;
  }

  public void CreateSome(int amount)
  {
    quantity += amount;
    UpdateDisplay();
  }

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

  private void Start()
  {
    UpdateDisplay();
  }

  void UpdateDisplay()
  {
    quantityDisplay.text = quantity.ToString();
  }
}
