using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillSprite : MonoBehaviour
{
  private Image mySprite;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.P))
    {
      RefreshSprite();
    }
  }

  private void RefreshSprite()
  {
    if (GetComponent<Image>()) mySprite = GetComponent<Image>();
    mySprite.sprite = RandomUtils.GenerateImage();
    mySprite.color = RandomUtils.GenerateColor();
  }
}
