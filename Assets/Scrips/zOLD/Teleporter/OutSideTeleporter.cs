using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutSideTeleporter : MonoBehaviour
{
   public GameObject Destination;
   public GameObject teleporterToModify;
   public GameObject newTeleporterDestination;

   public GameObject messageToChange;

   public Sprite newMessage;
   


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
           
           if(teleporterToModify && newTeleporterDestination)
            {
                BaseTeleporter X = teleporterToModify.GetComponent<BaseTeleporter>();
                X.SetDestination(newTeleporterDestination);   
            }
        
            if(messageToChange && newMessage)
            {
                SpriteRenderer Y = messageToChange.GetComponent<SpriteRenderer>();
                Y.sprite = newMessage;
            }

        

       }
   }

   public void SetDestination(GameObject newDestination)
   {
       Destination = newDestination;
   }
}
