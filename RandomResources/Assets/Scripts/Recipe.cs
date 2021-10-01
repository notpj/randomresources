using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour
{
  [SerializeField]
  GameObject ingredientPrefab, resultPrefab;
  [SerializeField]
  Transform ingredientTransform, resultTransform;

  List<Resource> resourcesNeeded = new List<Resource>();

  int uses;

  int componentIDRequired;
  int componentsRequired;
  int productIDGained;
  int productsGiven;

  int componentsConsumed = 0;

  public void ConsumeResource()
  {
    if (componentsConsumed >= componentsRequired) return;

    if (PlayerController.TakeComponentIfAvailable(componentIDRequired))
    {
      ++componentsConsumed;
    }

    UpdateResources();

    if (componentsConsumed >= componentsRequired) EnableTransaction();
  }

  public void ReturnResource()
  {
    if (componentsConsumed <= 0) return;

    PlayerController.AwardComponents(componentIDRequired, 1);
    --componentsConsumed;
    UpdateResources();
  }

  public void CompleteTransaction()
  {
    componentsConsumed = 0;
    PlayerController.AwardProducts(productIDGained, productsGiven);
    UpdateResources();
  }

  private void EnableTransaction()
  {

  }

  private void UpdateResources()
  {
    foreach(Resource r in resourcesNeeded) r.DisplayEmpty();
    for (int i = 0; i < componentsConsumed; ++i) resourcesNeeded[i].DisplayFilled();
  }

  private void Start()
  {
    GenerateRecipe();
  }

  void GenerateRecipe()
  {
    componentsConsumed = 0;
    resourcesNeeded.Clear();

    componentIDRequired = Random.Range(1, PlayerController.GetComponentQuantity() + 1);
    componentsRequired = Random.Range(2, 3 + 1);

    for(int i = 0; i < componentsRequired; ++i)
    {
      Resource resource = Instantiate(ingredientPrefab, ingredientTransform).GetComponentInChildren<Resource>();
      resource.SetComponentID(componentIDRequired);
      resourcesNeeded.Add(resource);
    }

    productIDGained = Random.Range(1, PlayerController.GetProductQuantity() + 1);
    productsGiven = Random.Range(1, 2 + 1);

    for (int i = 0; i < productsGiven; ++i)
    {
      Resource resource = Instantiate(resultPrefab, resultTransform).GetComponentInChildren<Resource>();
      resource.SetProductID(productIDGained);
      resource.DisplayFilled();
    }
  }
}
