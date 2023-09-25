using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandling : MonoBehaviour
{
    // https://sharpcoderblog.com/blog/unity-3d-openable-door-tutorial
    
    private bool isDoorOpen = false;
    private bool playerNear = false;
    private float defaultRotationAngle;
    private float currentRotationAngle;

    private float openTime = 0;


    public float finalDoorRotationAngle = -90f;
    public float doorOpeningSpeed = 2f;

    void Start()
    {
        defaultRotationAngle = transform.localEulerAngles.y;
        currentRotationAngle = defaultRotationAngle;
    }

    
    void Update()
    {
        if(openTime<1)
            {
                openTime += Time.deltaTime * doorOpeningSpeed;
            }
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,
        Mathf.LerpAngle(currentRotationAngle,(defaultRotationAngle+(isDoorOpen ? finalDoorRotationAngle : 0)),openTime),
        transform.localEulerAngles.z);
        
        
        if(Input.GetKeyDown(KeyCode.F) && playerNear && !isDoorOpen)
        {
            isDoorOpen = true;
            currentRotationAngle = transform.localEulerAngles.y;
            openTime = 0;
        }
    }

    void OnTriggerEnter(Collider Trigger)
    {
        if(Trigger.CompareTag("Player"))
        {
            playerNear = true;
        }
        
    }

    void OnTriggerExit(Collider Trigger)
    {
        if(Trigger.CompareTag("Player"))
        {
            playerNear = false;
        }
    }

}
