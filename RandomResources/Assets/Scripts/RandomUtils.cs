using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomUtils
{
  static List<Sprite> SpriteList = null;
  public static string GenerateName()
  {
    string output = "";

    int rand = Random.Range(2, 9);

    for (int i = 0; i <= rand; ++i)
    {
      if (i % 2 == 0)
      {
        output += GenerateConsonant();
      }
      else if (i % 2 == 1)
      {
        output += GenerateVowel();
      }
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
    return SpriteList[rand];
  }

  public static Color GenerateColor()
  {
    Color output = Random.ColorHSV();
    return output;
  }

  static char GenerateConsonant()
  {
    string st = "bcdfghjklmnpqrstvwxyz";
    char c = st[Random.Range(0, st.Length)];
    return c;
  }

  static char GenerateVowel()
  {
    string st = "aeiou";
    char c = st[Random.Range(0, st.Length)];
    return c;
  }
}
