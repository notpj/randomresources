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

  void GenerateRecipe()
  {
    
  }
}
