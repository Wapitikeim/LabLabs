using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloorTrigger : MonoBehaviour
{
    public float speed;

    public float downLength;

    public GameObject floorToMove;
    
    private Vector3 defaultFloorPoistion;

    private Vector3 targetPosition;


    void Start()
    {
        defaultFloorPoistion = floorToMove.transform.position;
        targetPosition = new Vector3(floorToMove.transform.position.x, (floorToMove.transform.position.y - downLength), floorToMove.transform.position.z);
    }

    void OnTriggerEnter(Collider Trigger)
    {
        if(Trigger.tag == "Player")
        {
            DeleteMFloorScriptIfExist();
            
            InitiateFloorMovingProcess(true);
        }
        
    }

    void OnTriggerExit(Collider Trigger)
    {
        if(Trigger.tag == "Player")
        {
            DeleteMFloorScriptIfExist();

            InitiateFloorMovingProcess(false);
        }
    }

    private void DeleteMFloorScriptIfExist()
    {
        if(floorToMove.GetComponent<MoveFloorUpDown>() != null)
            {
                Destroy(floorToMove.GetComponent<MoveFloorUpDown>());
            }
    }

    private void InitiateFloorMovingProcess(bool UpOrDown)
    {
        //true = Down
        //false = Back to Default
        Vector3 position;
        if(UpOrDown == true)
        {
            position = targetPosition;
        }
        else 
        {
            position = defaultFloorPoistion;
        }
        MoveFloorUpDown MoveFloorScript =  floorToMove.AddComponent<MoveFloorUpDown>();
        MoveFloorScript.SetSpeed(speed);
        MoveFloorScript.SetTargetPosition(position);
    }

}
