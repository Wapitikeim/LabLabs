using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Dash : MonoBehaviour
{
    
    private Vector3 moveInDirection;

    public float maxDashTime = 1f;
    public float dashDistance = 20f;
    public float dashStoppingSpeed = 0.1f;
    private float currentDashTime;
    private float dashSpeed = 6f;
    public float cooldown = 1f;
    private float cooldTimer = 0f;


    CharacterController charContr;

    

    void Start()
    {
        currentDashTime = maxDashTime;
        charContr = GetComponent<CharacterController>();
    }

        void Update()
    {
        if(Input.GetButtonDown("ActionB") && cooldTimer <= 0)
        {
            currentDashTime = 0f;
        }
        if(currentDashTime < maxDashTime)
        {
            moveInDirection = transform.forward * dashDistance;
            currentDashTime += dashStoppingSpeed;
            charContr.Move(moveInDirection * Time.deltaTime * dashSpeed);
            cooldTimer = cooldown;
        }
        else
        {
            moveInDirection = Vector3.zero;
            if(cooldTimer >= 0)
            {
               cooldTimer -= Time.deltaTime; 
            }     
        }
        
    }

}
