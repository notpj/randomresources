using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ScoreTally : MonoBehaviour
{
  [SerializeField]
  GameObject resourcePoolTallyPrefab, resourcePoolParent;

  [SerializeField]
  Image scoreIcon;

  [SerializeField]
  TextMeshProUGUI scoreText;

  int score = 0;
  List<ResourcePool> pools = new List<ResourcePool>();
  public void RestartGame()
  {
    SceneManager.LoadScene(0);
  }

  private void Start()
  {
    scoreIcon.sprite = ActionWallet.CurrencyIcon;
    int ID = 0;
    foreach(int i in GameController.lastHighScore)
    {
      ResourcePool pool = Instantiate(resourcePoolTallyPrefab, resourcePoolParent.transform).GetComponent<ResourcePool>();
      InitializeResourcePool(pool, ++ID);
      pool.CreateSome(i);
      pools.Add(pool);
    }
    StartCoroutine(AnimateTally(0));
  }

  private void InitializeResourcePool(ResourcePool pool, int ID)
  {
    if (!pool)
    {
      Debug.LogError("Non resource pool type found in resource pool parent");
      return;
    }

    Resource resource = pool.GetResource();
    resource.DisplayFilled();

    resource.SetComponentID(ID);
    pool.UpdateName(ID);
    pool.UpdatePrice(ID);
  }

  IEnumerator AnimateTally(int id)
  {
    yield return new WaitForSecondsRealtime(1.0f);

    if (pools.Count > id)
    {
      pools[id].Interact();
      score += GameController.lastHighScore[id] * Resource.GetValue(id + 1);
      scoreText.text = score.ToString();
      StartCoroutine(AnimateTally(id + 1));
    }
  }
}
