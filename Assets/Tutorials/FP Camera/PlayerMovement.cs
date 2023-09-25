using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController playerCharacterController;
    public float movementSpeed = 1f;
    public float Gravity = 9.8f;

    public GameObject PlayerCamera;
    
    private float velocity = 0;

    
    
    // Start is called before the first frame update
    void Start()
    {
        playerCharacterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        playerCharacterController.transform.LookAt(PlayerCamera.transform.rotation.eulerAngles);

        float horizontal = Input.GetAxis("Horizontal") * movementSpeed;
        float vertical = Input.GetAxis("Vertical") * movementSpeed;

        playerCharacterController.Move((Vector3.right * horizontal + Vector3.forward *vertical) * Time.deltaTime);

        if(playerCharacterController.isGrounded)
        {
            velocity = 0;
        }
        else
        {
            velocity -= Gravity * Time.deltaTime;
            playerCharacterController.Move(new Vector3(0,velocity,0));
        }

    }
}
