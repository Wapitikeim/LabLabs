using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWalls : MonoBehaviour
{
    public GameObject[] MovableWallsList;

    void OnTriggerEnter(Collider Trigger)
   {
       if(Trigger.tag == "Player")
       {
           foreach(GameObject i in MovableWallsList)
           {
               if(i != null)
               {
                    MovableWalls currentObject = i.GetComponent<MovableWalls>();
                    currentObject.initiateOpeningProzess();
               }
               
           }
       }
   }
}
