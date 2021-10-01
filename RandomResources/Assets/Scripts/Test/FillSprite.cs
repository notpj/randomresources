using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillSprite : MonoBehaviour
{
  private SpriteRenderer mySprite;
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
    if (GetComponent<SpriteRenderer>()) mySprite = GetComponent<SpriteRenderer>();
    mySprite.sprite = RandomUtils.GenerateImage();
  }
}
