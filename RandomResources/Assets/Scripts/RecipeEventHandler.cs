using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RecipeEventHandler : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
  Recipe recipe;

  private void Awake()
  {
    recipe = GetComponent<Recipe>();
  }

  public void OnPointerClick(PointerEventData eventData)
  {
    if (eventData.button == PointerEventData.InputButton.Left)
    {
      recipe.ConsumeResource();
    }
    if (eventData.button == PointerEventData.InputButton.Right)
    {
      recipe.ReturnResource();
    }
  }

  public void OnPointerDown(PointerEventData eventData)
  {
  }

  public void OnPointerUp(PointerEventData eventData)
  {
  }
}
