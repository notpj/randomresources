using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Money : MonoBehaviour
{
  public static TextMeshProUGUI MoneyText;
  static int CurrentMoney = 0;

  static void UpdateText()
  {
    MoneyText.text = "$" + CurrentMoney;
  }

  public static void ModifyMoney(int input)
  {
    CurrentMoney += input;
    UpdateText();
  }
}
