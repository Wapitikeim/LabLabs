using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityHandler : MonoBehaviour
{
    private UnityEngine.CharacterController charContr;
    private float gravity = -9.81f;
    Vector3 velocity;

    public Transform groundCheckModule;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;


    //Jumping currently implemented in ApplyForce() -> REFACTOR!
    public float jumpHeight = 3f;


    void Start()
    {
        charContr = GetComponent<UnityEngine.CharacterController>();
    }

    void Update()
    {
        ApplyForce();
    }

    public bool IsThePlayerGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheckModule.position, groundDistance, groundMask);
        return isGrounded;
    }

    private void ApplyForce()
    {
        if(IsThePlayerGrounded() && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        if(Input.GetButtonDown("Jump") && IsThePlayerGrounded())
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        charContr.Move(velocity * Time.deltaTime);
    }

}
