using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    PlayerLife dead;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        dead = GetComponent<PlayerLife>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        if (verticalInput > 0.0)
        {
            animator.SetBool("isWalkingF", true);
        }

        if (verticalInput < 0.0)
        {
            animator.SetBool("isWalkingB", true);
        }

        if (verticalInput == 0.0)
        {
            animator.SetBool("isWalkingF", false);
            animator.SetBool("isWalkingB", false);
        }

        if (horizontalInput < 0.0)
        {
            animator.SetBool("isWalkingL", true);
        }

        if (horizontalInput > 0.0)
        {
            animator.SetBool("isWalkingR", true);
        }

        if (horizontalInput == 0.0)
        {
            animator.SetBool("isWalkingL", false);
            animator.SetBool("isWalkingR", false);
        }

        if (Convert.ToBoolean(Input.GetButtonDown("Jump") && IsGrounded()))
        {
            animator.SetBool("isJumping", true);
        }

        if (!Convert.ToBoolean(Input.GetButtonDown("Jump") && IsGrounded()))
        {
            animator.SetBool("isJumping", false);
        }

        if (dead.dead)
        {
            animator.SetBool("isDead", true);
        }
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}
