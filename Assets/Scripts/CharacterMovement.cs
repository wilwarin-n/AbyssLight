using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizantalMove = 0f;

    bool jump = false;
    bool crouch = false;
    


    void Update()
    {
        horizantalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizantalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("Jumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        
    }

    public void OnLanding()
    {
        animator.SetBool("Jumping", false);
    }

    public void OnCrouching(bool Crouching)
    {
        animator.SetBool("Crouching", Crouching);
    }

    void FixedUpdate()
    {
        controller.Move(horizantalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    
}
