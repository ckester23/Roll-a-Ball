using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

[RequireComponent(typeof(CharacterController))]

public class PlayerJump : MonoBehaviour
{
    // Jump Variables
    [SerializeField] private float jumpHeight = 5.0f;
    private bool canDoubleJump;
    private bool IsGrounded = false; 

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void MovementJump()
    {
        // if on ground, jump the player, and set double jump
        if (IsGrounded)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            IsGrounded = false; 
            canDoubleJump = true;
        }

        // if in air, jump player, un-set double jump
        else if (canDoubleJump)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            IsGrounded = false;
            canDoubleJump = false;
        }
      
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
        } 
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            IsGrounded = false;
        }
    }

    void OnJump()
    {
        MovementJump();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //MovementJump();
    }
}
