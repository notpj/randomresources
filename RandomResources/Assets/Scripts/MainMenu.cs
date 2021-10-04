using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public TextMeshProUGUI Intro;
  public TextMeshProUGUI Brief;
  public TextMeshProUGUI Marathon;
  public GameObject Enter;
  public bool ShortGame = true;
  // Start is called before the first frame update
  void Awake()
  {
    GameController.ResetGame();
  }
  void Start()
  {
    Brief.text = RandomUtils.GenerateShortName();
    Marathon.text = RandomUtils.GenerateLongName();
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void SelectBrief()
  {
    FindObjectOfType<AudioManager>().PlayClick1();
    Brief.color = Color.green;
    Marathon.color = Color.white;
    ActionWallet.MaxActions = 12;
    Intro.text = "12";
    ShortGame = true;
    PlayerController.startingPools = 6;
    if (!Enter.activeSelf) Enter.SetActive(true);
  }

  public void SelectMarathon()
  {
    FindObjectOfType<AudioManager>().PlayClick1();
    Brief.color = Color.white;
    Marathon.color = Color.green;
    ActionWallet.MaxActions = 24;
    Intro.text = "24";
    ShortGame = false;
    PlayerController.startingPools = 3;
    if (!Enter.activeSelf) Enter.SetActive(true);
  }

  public void LoadGame()
  {
    FindObjectOfType<AudioManager>().PlayClick3();
    if (ShortGame) SceneManager.LoadScene(1);
    else SceneManager.LoadScene(1);
  }
}
