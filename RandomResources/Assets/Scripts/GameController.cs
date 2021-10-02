using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class GameController
{
  static public List<int> lastHighScore;
  static public void ResetGame()
  {
    RandomUtils.ResetRandom();
    Resource.ResetResources();
    ActionWallet.ActionIcon = null;

    ChooseStartupSymbols();
  }

  static void ChooseStartupSymbols()
  {
    ActionWallet.ActionIcon = RandomUtils.GenerateImage();
  }
}
