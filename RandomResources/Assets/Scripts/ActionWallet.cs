using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

  public delegate void VoidVoid();
  public static event VoidVoid Event_ActionsDepleted;

  public static void UseAction()
  {
    --Instance.actionsRemaining;
    if (Instance.actionsRemaining <= 0 && Event_ActionsDepleted != null) Event_ActionsDepleted();
  }

  public static void RefreshActions()
  {
    Instance.actionsRemaining = 10;
  }

  private int actionsRemaining = 10;

  private void Awake()
  {
    Instance = this;
  }
}
