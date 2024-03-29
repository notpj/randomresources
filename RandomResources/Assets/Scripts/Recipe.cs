using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Recipe : MonoBehaviour
{
  public delegate void VoidVoid();
  static public event VoidVoid Event_RecipeRemoved;

  [SerializeField]
  Button submitButton;

  [SerializeField]
  GameObject ingredientPrefab;
  [SerializeField]
  Transform ingredientTransform, resultTransform;

  [SerializeField]
  TextMeshProUGUI usesCounter, toolName, confirmText;

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
  }

  public void ReturnResource()
  {
    if (componentsConsumed <= 0) return;

    PlayerController.AwardComponents(componentIDRequired, 1);
    --componentsConsumed;

    FindObjectOfType<AudioManager>().PlayClick2();

    UpdateResources();
  }

  public void CompleteTransaction()
  {
    componentsConsumed = 0;
    PlayerController.AwardComponents(productIDGained, productsGiven);
    --uses;

    FindObjectOfType<AudioManager>().PlayClick3();

    UpdateResources();
    ActionWallet.UseAction();
    if (uses <= 0) RemoveRecipe();
  }

  public void DismissRecipe()
  {
    while (componentsConsumed > 0)
    {
      PlayerController.AwardComponents(componentIDRequired, 1);
      --componentsConsumed;
    }

    FindObjectOfType<AudioManager>().PlayClick2();

    ActionWallet.UseAction();
    RemoveRecipe();
  }

  private void RemoveRecipe()
  {
    transform.SetParent(null, false);
    Destroy(gameObject);
    if (Event_RecipeRemoved != null) Event_RecipeRemoved();
  }

  private void UpdateResources()
  {
    foreach (Resource r in resourcesNeeded) r.DisplayEmpty();
    for (int i = 0; i < componentsConsumed; ++i) resourcesNeeded[i].DisplayFilled();
    submitButton.interactable = (componentsConsumed >= componentsRequired);
    usesCounter.text = uses.ToString();
  }

  private void Start()
  {
    GenerateRecipe();
  }

  void GenerateRecipe()
  {
    componentsConsumed = 0;
    resourcesNeeded.Clear();
    submitButton.interactable = (false);

    uses = Random.Range(1, 4);

    componentIDRequired = Random.Range(1, PlayerController.GetComponentQuantity() + 1);
    componentsRequired = Random.Range(1, 3 + 1);

    for (int i = 0; i < componentsRequired; ++i)
    {
      Resource resource = Instantiate(ingredientPrefab, ingredientTransform).GetComponentInChildren<Resource>();
      resource.SetComponentID(componentIDRequired);
      resourcesNeeded.Add(resource);
    }

    do
    {
      productIDGained = Random.Range(1, PlayerController.GetComponentQuantity() + 2);
    }
    while (productIDGained == componentIDRequired);

    productsGiven = Random.Range(1, 3 + 1);

    for (int i = 0; i < productsGiven; ++i)
    {
      Resource resource = Instantiate(ingredientPrefab, resultTransform).GetComponentInChildren<Resource>();
      resource.SetComponentID(productIDGained);
      resource.DisplayFilled();
    }

    UpdateResources();

    (string, string) machineAction = RandomUtils.GenerateMachine();

    toolName.text = Resource.GetName(componentIDRequired) + ' ' + machineAction.Item1;
    confirmText.text = machineAction.Item2;
  }
}
