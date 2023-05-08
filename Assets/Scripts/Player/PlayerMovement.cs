using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  private PlayerAnimator playerAnimator;
  private BoxCollider2D boxCollider;
  private Rigidbody2D rb;
  private SpriteRenderer sprite;
  private float x = 0f;
  [SerializeField] private LayerMask groundLayer;
  [SerializeField] private float jumpForce = 14f;
  [SerializeField] private float moveSpeed = 7f;
  [SerializeField] private AudioSource jumpSoundEffect;

  private void Start()
  {
    playerAnimator = GetComponent<PlayerAnimator>();
    boxCollider = GetComponent<BoxCollider2D>();
    rb = GetComponent<Rigidbody2D>();
    sprite = GetComponent<SpriteRenderer>();
  }

  private void Update()
  {
    if (rb.bodyType == RigidbodyType2D.Static) return;

    x = Input.GetAxisRaw("Horizontal");
    float moveBy = x * moveSpeed;
    rb.velocity = new Vector2(moveBy, rb.velocity.y);

    if (Input.GetButtonDown("Jump") && IsGrounded)
    {
      jumpSoundEffect.Play();
      rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    FlipPlayer();
    UpdateAnimationState();
  }

  private void FlipPlayer()
  {
    sprite.flipX = (x != 0) ? (x < 0) : sprite.flipX;
  }

  private void UpdateAnimationState()
  {
    playerAnimator.State = x != 0 ? PlayerAnimator.AnimationState.Running : PlayerAnimator.AnimationState.Idle;

    if (rb.velocity.y > .1f) playerAnimator.State = PlayerAnimator.AnimationState.Jumping;
    else if (rb.velocity.y < -.1f) playerAnimator.State = PlayerAnimator.AnimationState.Falling;
  }

  public bool IsGrounded
  {
    get => Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, groundLayer);
  }
}
