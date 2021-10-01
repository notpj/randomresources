using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomUtils
{
  static List<Sprite> SpriteList = null;
  public static string GenerateName()
  {
    string output = "";

    int rand = Random.Range(2, 5);

    for (int i = 0; i <= rand; ++i)
    {
      if (i == 0) output += GenerateConsonant(true);
      else if (i % 2 == 0) output += GenerateConsonant();
      else if (i % 2 == 1) output += GenerateVowel();
    }

    return output;
  }

  public static Sprite GenerateImage()
  {
    if (SpriteList == null)
    {
      //Generate the list
      SpriteList = new List<Sprite>(Resources.LoadAll<Sprite>("Icons"));
    }

    int rand = Random.Range(0, SpriteList.Count);

    Sprite output = SpriteList[rand];

    SpriteList.RemoveAt(rand);

    return output;
  }

  public static Color GenerateColor()
  {
    Color output = Random.ColorHSV();
    return output;
  }

  public static int GeneratePrice()
  {
    return Random.Range(0, 30);
  }

  static char GenerateConsonant(bool capital = false)
  {
    string st;

    if (capital) st = "BCDFGHJKLMNPQRSTVWXYZ";
    else st = "bcdfghjklmnpqrstvwxyz";

    char c = st[Random.Range(0, st.Length)];
    return c;
  }

  static char GenerateVowel(bool capital = false)
  {
    string st;

    if (capital) st = "AEIOU";
    else st = "aeiou";

    char c = st[Random.Range(0, st.Length)];
    return c;
  }
}
