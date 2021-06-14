using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationStateController : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator m_animator;


    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool runPressed = Input.GetButton("Run");
        bool crouchPressed = Input.GetButton("Crouch");

        bool forwardPressed = Input.GetButton("Vertical");
        bool sidePressed = Input.GetButton("Horizontal");

        bool aimPressed = Input.GetButton("Aim");

        bool jumpPressed = Input.GetButtonDown("Jump");

        // if (aimPressed) 
        // {
   
        if (Input.GetAxis("Vertical") > 0)
        {
            m_animator.SetBool("imWalkingForwards", true);
            m_animator.SetBool("imWalkingBackwards", false);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            m_animator.SetBool("imWalkingForwards", false);
            m_animator.SetBool("imWalkingBackwards", true);
        }
        else
        {
             m_animator.SetBool("imWalkingForwards", false);
             m_animator.SetBool("imWalkingBackwards", false);
        }
        
       

        if (Input.GetAxis("Horizontal") > 0)
        {
            m_animator.SetBool("imWalkingRight", true);
            m_animator.SetBool("imWalkingLeft", false);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            m_animator.SetBool("imWalkingRight", false);
            m_animator.SetBool("imWalkingLeft", true);
        }
        else
        {
            m_animator.SetBool("imWalkingRight", false);
            m_animator.SetBool("imWalkingLeft", false);
        }
        
        
       // }


        if (forwardPressed || sidePressed)
        {
            m_animator.SetBool("imWalking", true);
        }
        else 
        {
            m_animator.SetBool("imWalking", false);
        }

        if (runPressed && m_animator.GetBool("imWalking"))
        {
            m_animator.SetBool("imRunning", true);
        }
        else 
        {
            m_animator.SetBool("imRunning", false);
        }

        if (crouchPressed)
        {
            m_animator.SetBool("imCrouching", true);
        }
        else
        {
            m_animator.SetBool("imCrouching", false);
        }

        if (jumpPressed) 
        {
            m_animator.SetTrigger("Jump");
        }
    }
}
