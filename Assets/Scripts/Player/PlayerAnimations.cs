using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Invoke("PlayerAnim", 0.1f);
    }
    void PlayerAnim()
    {
        if (PlayerController.Instance.isGrounded)
        {
            anim.SetBool("Jump", false);
            anim.SetBool("Move", PlayerController.Instance.isMoving);
        }
        else if (!PlayerController.Instance.isGrounded)
        {
            anim.SetBool("Jump", true);
        }
    }
}
