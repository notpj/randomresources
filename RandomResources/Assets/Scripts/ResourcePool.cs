using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ResourcePool : MonoBehaviour
{
  [SerializeField]
  TextMeshProUGUI quantityDisplay, resourceName /*resourceValue*/;
  int quantity = 0;

  int tier;

  Resource resource;

  Vector3 defaultScale;

  public bool TakeSome(int amount = 1)
  {
    if (quantity - amount >= 0)
    {
      quantity -= amount;
      UpdateDisplay();
      Interact();
      return true;
    }

    return false;
  }

  public void CreateSome(int amount)
  {
    quantity += amount;
    UpdateDisplay();
    Interact();
  }

  public Resource GetResource()
  {
    return resource;
  }

  public void UpdateName(int ID)
  {
    resourceName.text = Resource.GetName(ID);
  }

  public void UpdatePrice(int ID)
  {
    //resourceValue.text = Resource.GetValue(ID).ToString();
  }

  private void Awake()
  {
    defaultScale = transform.localScale;
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

  void Interact()
  {
    StopAllCoroutines();
    StartCoroutine(AnimateInteraction());
  }

  IEnumerator AnimateInteraction()
  {
    Vector3 bigScale = defaultScale * 1.3f;
    transform.localScale = bigScale;

    int frames = 60;
    for (int i = 0; i < frames; ++i)
    {
      transform.localScale = Vector3.Lerp(defaultScale, bigScale, 1.0f - (i / (float)frames));
      yield return new WaitForEndOfFrame();
    }

    transform.localScale = defaultScale;
  }
}
