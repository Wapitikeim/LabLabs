using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePlayerBox : MonoBehaviour
{
    void OnTriggerEnter(Collider Trigger)
    {
        if(Trigger.tag == "Player")
        {
            GameObject playerRef = GameObject.FindGameObjectWithTag("Player");
            playerRef.tag.Remove(0);
            playerRef.tag = "DisguisedPlayer";
        }
    }
    void OnTriggerExit(Collider Trigger)
    {
        if(Trigger.tag =="DisguisedPlayer")
        {
            GameObject playerRef = GameObject.FindGameObjectWithTag("DisguisedPlayer");
            playerRef.tag.Remove(0);
            playerRef.tag = "Player";
        }
    }
}
