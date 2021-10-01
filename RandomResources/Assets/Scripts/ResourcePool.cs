using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ResourcePool : MonoBehaviour
{
  public enum ResourceType
  {
    Component,
    Product
  }
  
  [SerializeField]
  TextMeshProUGUI quantityDisplay;
  int quantity = 0;

  [SerializeField]
  ResourceType type = ResourceType.Component;

  Resource resource;

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

  public Resource GetResource()
  {
    return resource;
  }

  private void Awake()
  {
    resource = GetComponentInChildren<Resource>();
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
