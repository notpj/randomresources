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
    RefreshSprite();
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void RefreshSprite()
  {
    if (GetComponent<Image>()) mySprite = GetComponent<Image>();
    mySprite.sprite = ActionWallet.ActionIcon;
  }
}
