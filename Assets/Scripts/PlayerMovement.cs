using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  private Rigidbody2D rb;
  public float jumpForce = 14f;
  public float moveSpeed = 7f;

  // Start is called before the first frame update
  private void Start()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  private void Update()
  {
    float x = Input.GetAxisRaw("Horizontal");
    float moveBy = x * moveSpeed;
    rb.velocity = new Vector2(moveBy, rb.velocity.y);

    if (Input.GetButtonDown("Jump"))
    {
      rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
  }
}
