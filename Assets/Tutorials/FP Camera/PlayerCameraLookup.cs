using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraLookup : MonoBehaviour
{
    public float horizontalSpeed = 1f;
    public float verticalSpeed = 1f;

    private float xRotation = 0f;
    private float yRotation = 0f;
    private Camera PlayerCamera;
    
    
    void Start()
    {
        PlayerCamera = Camera.main;
    }

    
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * horizontalSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * verticalSpeed;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        PlayerCamera.transform.eulerAngles = new Vector3(xRotation, yRotation, 0f);
    }
}
