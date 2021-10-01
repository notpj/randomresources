using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ResourcePool : MonoBehaviour
{
  [SerializeField]
  TextMeshProUGUI quantityDisplay;
  int quantity = 0;

  int tier;

  Resource resource;

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
