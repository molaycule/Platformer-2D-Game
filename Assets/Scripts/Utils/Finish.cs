using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
  private AudioSource finishSoundEffect;
  private bool levelCompleted = false;

  private void Start()
  {
    finishSoundEffect = GetComponent<AudioSource>();
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.CompareTag("Player") && !levelCompleted)
    {
      finishSoundEffect.Play();
      levelCompleted = true;
      Invoke("FinishLevel", 2f);
    }
  }

  private void FinishLevel()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }
}
