using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  private PlayerAnimator playerAnimator;
  private Rigidbody2D rb;
  private SpriteRenderer sprite;
  [SerializeField] private float jumpForce = 14f;
  [SerializeField] private float moveSpeed = 7f;

  private void Start()
  {
    playerAnimator = GetComponent<PlayerAnimator>();
    rb = GetComponent<Rigidbody2D>();
    sprite = GetComponent<SpriteRenderer>();
  }

  private void Update()
  {
    float x = Input.GetAxisRaw("Horizontal");
    float moveBy = x * moveSpeed;
    rb.velocity = new Vector2(moveBy, rb.velocity.y);
    playerAnimator.IsRunning = x != 0;
    sprite.flipX = (x != 0) ? (x < 0) : sprite.flipX;

    if (Input.GetButtonDown("Jump"))
    {
      rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
  }
}
