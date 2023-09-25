
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlyMovement : MonoBehaviour
{
    private CharacterController charContr;

    public float movementSpeed = 12f;

    void Start()
    {
        charContr = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 moveDirection = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");

        charContr.Move(moveDirection*movementSpeed*Time.deltaTime);

        
    }

    public void SetPosition(Vector3 newPosition)
    {
        charContr.enabled = false;
        charContr.transform.position = newPosition;
        charContr.enabled = true;
    }
}
