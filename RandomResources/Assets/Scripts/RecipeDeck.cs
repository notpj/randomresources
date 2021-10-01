using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeDeck : MonoBehaviour
{
  [SerializeField]
  GameObject recipeCardPrefab;
  [SerializeField]
  Transform recipeParent;

  [SerializeField]
  int maximumCards = 6;

  float cardTimer = 30;

  private void Start()
  {
    FillCards();
    //StartCoroutine(DealCards());
  }

  private void OnEnable()
  {
    Recipe.Event_RecipeRemoved += FillCards;
  }
  private void OnDisable()
  {
    Recipe.Event_RecipeRemoved -= FillCards;
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space)) CreateCard();
  }

  private void FillCards()
  {
    for (int i = 0; i < maximumCards; ++i) CreateCard();
  }

  private void CreateCard()
  {
    if (recipeParent.childCount >= maximumCards) return;
    Instantiate(recipeCardPrefab, recipeParent);
  }

  private IEnumerator DealCards()
  {
    yield return new WaitForSeconds(30.0f);
    CreateCard();
    StartCoroutine(DealCards());
  }
}
