using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTeleporter : MonoBehaviour
{
   public GameObject Destination;
   private GameObject Player;

   private PlyMovement moveScriptRef;   
   void Start()
   {
        Player = GameObject.FindWithTag("Player");
        moveScriptRef = Player.GetComponent<PlyMovement>();
   }

   void OnTriggerEnter(Collider Trigger)
   {
       if(Trigger.CompareTag("Player"))
       {
           moveScriptRef.SetPosition(Destination.transform.position);
       }
   }

   public void SetDestination(GameObject newDestination)
   {
       Destination = newDestination;
   }
}
