using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
  public enum AnimationState
  {
    Idle,
    Running,
    Jumping,
    Falling
  }

  private Animator anim;
  private AnimationState state;

  public AnimationState State
  {
    get => state;
    set
    {
      state = value;
      anim.SetInteger("state", (int)state);
    }
  }

  private void Start()
  {
    anim = GetComponent<Animator>();
  }
}
