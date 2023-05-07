using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
  private Animator anim;
  private bool isRunning;

  public bool IsRunning
  {
    get { return isRunning; }
    set
    {
      isRunning = value;
      if (anim != null)
      {
        anim.SetBool("isRunning", isRunning);
      }
    }
  }

  private void Start()
  {
    anim = GetComponent<Animator>();
  }
}
