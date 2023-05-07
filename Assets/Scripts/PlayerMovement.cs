using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  private Rigidbody2D rb;
  public float jumpForce = 14f;

  // Start is called before the first frame update
  private void Start()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  private void Update()
  {
    if (Input.GetKeyDown("space"))
    {
      rb.velocity = Vector2.up * jumpForce;
    }
  }
}
