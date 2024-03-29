using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomUtils
{
  static List<Sprite> SpriteList = null;

  static public void ResetRandom()
  {
    SpriteList = null;
  }

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

  public static string GenerateLongName()
  {
    string output = "";

    int rand = Random.Range(5, 8);

    for (int i = 0; i <= rand; ++i)
    {
      if (i == 0) output += GenerateConsonant(true);
      else if (i % 2 == 0) output += GenerateConsonant();
      else if (i % 2 == 1) output += GenerateVowel();
    }

    return output;
  }

  public static string GenerateShortName()
  {
    string output = "";

    int rand = Random.Range(2, 4);

    for (int i = 0; i <= rand; ++i)
    {
      if (i == 0) output += GenerateConsonant(true);
      else if (i % 2 == 0) output += GenerateConsonant();
      else if (i % 2 == 1) output += GenerateVowel();
    }

    return output;
  }

  public static (string, string) GenerateMachine()
  {
    string[] machines =
    {
      "Slicer", "Pounder", "Clumper", "Dicer", "Juicer", "Clipper", "Snipper", "Ripper",
      "Eater", "Peeler", "Grabber", "Placer", "Dumper", "Thumper", "Jumper", "Mixer",
      "Chunker", "Fixer", "Dipper", "Spreader", "Duster", "Sucker", "Thrower", "Catcher",
      "Mincer", "Finder", "Storer", "Pourer", "Gripper", "Tipper", "Folder", "Holder",
      "Blaster", "Master", "Tool", "Machine", "Box", "Bucket", "Cache", "Chest"
    };
    string[] actions =
    {
      "Slice!", "Pound!", "Clump!", "Dice!", "Juice!", "Clip!", "Snip!", "Rip!",
      "Eat!", "Peel!", "Grab!", "Place!", "Dump!", "Thump!", "Jump!", "Mix!",
      "Chunk!", "Fix!", "Dip!", "Spread!", "Dust!", "Suck!", "Throw!", "Catch!",
      "Mince!", "Find!", "Store!", "Pour!", "Grip!", "Tip!", "Fold!", "Hold!",
      "Blast!", "Learn!", "Work!", "Operate!", "Store!", "Fill!", "Stash!", "Protect!"
    };

    int index = Random.Range(0, machines.Length);

    return (machines[index], actions[index]);
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

    if (output.r + output.g + output.b <= 0.3)
    {
      output.r *= 2;
      output.g *= 2;
      output.b *= 2;
    }

    output.a = 1.0f;
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
