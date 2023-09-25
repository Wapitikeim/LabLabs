using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationWithMouseInput : MonoBehaviour
{
    CharacterController charContr;
    void Start()
    {
        charContr = GetComponent<CharacterController>();
    }


    void Update()
    {
        float mouseHorizInput = Input.GetAxis("Mouse X");
        float mouseVerticalInput = Input.GetAxis("Mouse Y");
        Vector3 newRotation = new Vector3(mouseVerticalInput,mouseHorizInput,transform.rotation.z);
        charContr.transform.Rotate(newRotation);
    }
}
