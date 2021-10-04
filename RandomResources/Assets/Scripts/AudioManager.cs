using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
  public AudioClip Click1;
  public AudioClip Click2;
  public AudioClip Click3;
  public AudioSource AudioMan;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      Application.Quit();
    }
  }

  public void PlayClick1()
  {
    AudioMan.PlayOneShot(Click1, 0.5f);
  }

  public void PlayClick2()
  {
    AudioMan.PlayOneShot(Click2, 0.5f);
  }

  public void PlayClick3()
  {
    AudioMan.PlayOneShot(Click3, 0.5f);
  }
}
