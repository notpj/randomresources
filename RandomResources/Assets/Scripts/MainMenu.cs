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
    Brief.color = Color.green;
    Marathon.color = Color.white;
    Intro.text = "12";
    ShortGame = true;
    if (!Enter.activeSelf) Enter.SetActive(true);
  }

  public void SelectMarathon()
  {
    Brief.color = Color.white;
    Marathon.color = Color.green;
    Intro.text = "24";
    ShortGame = false;
    if (!Enter.activeSelf) Enter.SetActive(true);
  }

  public void LoadGame()
  {
    if (ShortGame) SceneManager.LoadScene(1);
    else SceneManager.LoadScene(2);
  }
}
