using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  private void OnEnable()
  {
    ActionWallet.Event_ActionsDepleted += GameOver;
  }

  private void OnDisable()
  {
    ActionWallet.Event_ActionsDepleted -= GameOver;
  }

  private void GameOver()
  {
    SceneManager.LoadScene(2);
  }
}
