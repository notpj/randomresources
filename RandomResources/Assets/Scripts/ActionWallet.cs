using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActionWallet : MonoBehaviour
{
  private static ActionWallet Instance
  {
    get
    {
      return instance;
    }
    set
    {
      if (instance) Debug.LogError("More than one player controller found! The game is broken now!");
      else instance = value;
    }
  }
  private static ActionWallet instance;

  public static Sprite ActionIcon;

  [SerializeField]
  TextMeshProUGUI actionCounter;
  [SerializeField]
  Image actionImage;

  public delegate void VoidVoid();
  public static event VoidVoid Event_ActionsDepleted;

  public static void UseAction()
  {
    --Instance.actionsRemaining;
    Instance.UpdateDisplay();
    if (Instance.actionsRemaining <= 0 && Event_ActionsDepleted != null) Event_ActionsDepleted();
  }

  public static void RefreshActions()
  {
    Instance.actionsRemaining = 10;
    Instance.UpdateDisplay();
  }

  private int actionsRemaining = 10;

  private void Awake()
  {
    Instance = this;
  }

  void UpdateDisplay()
  {
    if (ActionIcon == null) ActionIcon = RandomUtils.GenerateImage();
    actionImage.sprite = ActionIcon;
    actionCounter.text = actionsRemaining.ToString();
  }
}
