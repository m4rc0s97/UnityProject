using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class FPSCharacterController : MonoBehaviour
{
    public  CharacterController m_controller;
    private float               m_verticalVelocity;
    private float               m_isGroundedTimer; 
    public float                m_walkSpeed = 3.0f;
    // Crouched Value = 2.0f, Walk value = 3.0f, Run value = 7.0f

    private float               m_jumpHeight = 1.5f;
    private float               m_gravity = 9.81f;

    private Vector2             m_playerCameraRotation = Vector2.zero;
    public  float               m_playerCameraRotationSpeed = 2.0f;
    public  float               m_playerCameraRotationXLimit = 45.0f;
    public  Camera              m_playerCamera;

    public Animator             m_animator;

    private void Start()
    {
        m_controller = gameObject.GetComponent<CharacterController>();
    }
 
    void Update()
    {
        bool groundedPlayer = m_controller.isGrounded;
        if (groundedPlayer)
        {
            m_isGroundedTimer = 0.2f;
        }

        if (m_isGroundedTimer > 0)
        {
            m_isGroundedTimer -= Time.deltaTime;
        }
 
        if (groundedPlayer && m_verticalVelocity < 0)
        {
            m_verticalVelocity = 0f;
        }
 
        m_verticalVelocity -= m_gravity * Time.deltaTime;

        Vector3 move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        move *= m_walkSpeed;


        m_playerCameraRotation.y += Input.GetAxis("Mouse X") * m_playerCameraRotationSpeed;
        m_playerCameraRotation.x += -Input.GetAxis("Mouse Y") * m_playerCameraRotationSpeed;
        m_playerCameraRotation.x = Mathf.Clamp(m_playerCameraRotation.x, -m_playerCameraRotationXLimit, m_playerCameraRotationXLimit);

        if (m_playerCameraRotation.x > 0)
        {
            m_playerCamera.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (m_playerCameraRotation.x < -15)
        {
            m_playerCamera.transform.localRotation = Quaternion.Euler(-15, 0, 0);
        }
        else 
        {
            m_playerCamera.transform.localRotation = Quaternion.Euler(m_playerCameraRotation.x, 0, 0);
        }
        
        transform.eulerAngles = new Vector2(0, m_playerCameraRotation.y);



        if (Input.GetButtonDown("Run") || m_animator.GetBool("imRunning") == true)
        {
            m_walkSpeed = 7.0f;
        }
        else if (Input.GetButtonDown("Crouch"))
        {
            m_walkSpeed = 2.0f;
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            m_walkSpeed = 3.0f;
        }



        if (Input.GetButtonDown("Jump"))
        {
            if (m_isGroundedTimer > 0)
            {
                m_isGroundedTimer = 0;
 
                m_verticalVelocity += Mathf.Sqrt(m_jumpHeight * 2 * m_gravity);
            } 
        }
 
        
        move.y = m_verticalVelocity;
        m_controller.Move(move * Time.deltaTime);
    }
}
