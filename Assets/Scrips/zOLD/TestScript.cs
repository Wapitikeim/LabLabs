using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
   int x = 0;
   void onTriggerEnter(Collider Trigger)
   {
       if(Trigger.tag == "Player")
       {
           print("I Got Hit" + x + "times");
           x++;
       }

        if(Input.GetButtonDown("ActionB"))
           {
               RaycastHit hit; 
            int layermask = 1 << 9;
            layermask = ~layermask;
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5, layermask, QueryTriggerInteraction.Collide))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward)*hit.distance, Color.yellow, 2.0f);
            }
            
        }
       
   }
}
