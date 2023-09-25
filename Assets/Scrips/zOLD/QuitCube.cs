using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitCube : MonoBehaviour
{
    void OnTriggerEnter(Collider Trigger)
    {
        if(Trigger.tag == "Player")
        {
            Application.Quit();
            
        }
    }
}
