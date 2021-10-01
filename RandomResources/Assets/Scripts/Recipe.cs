using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour
{
  [SerializeField]
  GameObject ingredientPrefab, resultPrefab;
  [SerializeField]
  Transform ingredientTransform, resultTransform;

  int uses;

  private void Start()
  {
    GenerateRecipe();
  }

  void GenerateRecipe()
  {
    int componentIDRequired = Random.Range(1, PlayerController.GetComponentQuantity() + 1);
    int componentsRequired = Random.Range(2, 3 + 1);

    for(int i = 0; i < componentsRequired; ++i)
    {
      Resource resource = Instantiate(ingredientPrefab, ingredientTransform).GetComponentInChildren<Resource>();
      resource.SetComponentID(componentIDRequired);
    }

    int productIDGained = Random.Range(1, PlayerController.GetProductQuantity() + 1);
    int productsGiven = Random.Range(1, 2 + 1);

    for (int i = 0; i < productsGiven; ++i)
    {
      Resource resource = Instantiate(resultPrefab, resultTransform).GetComponentInChildren<Resource>();
      resource.SetProductID(productIDGained - 1);
    }
  }
}
