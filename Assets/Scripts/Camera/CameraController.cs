using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
  [SerializeField] private Transform playerTransform;
  [SerializeField] private float cameraYOffset = 1f;
  private PlayerMovement playerMovement;
  private float? initialPlayerYPosition;

  private void Start()
  {
    playerMovement = playerTransform.GetComponent<PlayerMovement>();
  }

  private void Update()
  {
    if (!initialPlayerYPosition.HasValue && playerMovement.IsGrounded)
    {
      initialPlayerYPosition = playerTransform.position.y - .1f;
    }

    if (playerTransform.position.y >= initialPlayerYPosition)
    {
      transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + cameraYOffset, transform.position.z);
    }
  }
}
