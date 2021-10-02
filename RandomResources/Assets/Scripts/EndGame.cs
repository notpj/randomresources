using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
  [SerializeField]
  GameObject endGameCanvas;

  IEnumerator TransitionToScore()
  {
    yield return new WaitForSecondsRealtime(1.0f);
    SceneManager.LoadScene(2);
  }

  private void OnEnable()
  {
    endGameCanvas.SetActive(false);
    ActionWallet.Event_ActionsDepleted += GameOver;
  }

  private void OnDisable()
  {
    ActionWallet.Event_ActionsDepleted -= GameOver;
  }

  private void GameOver()
  {
    endGameCanvas.SetActive(true);
    StartCoroutine(TransitionToScore());
  }
}
