using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
  [SerializeField] private AudioSource deathSoundEffect;
  private Rigidbody2D rb;
  private Animator anim;

  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("Trap"))
    {
      Die();
    }
  }

  private void Die()
  {
    deathSoundEffect.Play();
    rb.bodyType = RigidbodyType2D.Static;
    anim.SetTrigger("death");
  }

  // this method is called on Player's death animation clip event
  private void RestartLevel()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
}
