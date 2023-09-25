using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveIndividualDoor : MonoBehaviour
{
    
    enum DoorSide{left, right};
    DoorSide givenDoorSide;
    private bool doorStatus = false;
    private float opWidth;

    public static MoveIndividualDoor CreateScriptForDoor(GameObject WhichDoor, float openingWidth, bool open)
    {
        MoveIndividualDoor gameObjectWhichScriptAttachedTo = WhichDoor.AddComponent<MoveIndividualDoor>();
        gameObjectWhichScriptAttachedTo.doorStatus = open;
        gameObjectWhichScriptAttachedTo.opWidth = openingWidth;
        if (WhichDoor.ToString().Contains("LeftSide"))
        {
            gameObjectWhichScriptAttachedTo.givenDoorSide = DoorSide.left;
        }
        else
        {
            gameObjectWhichScriptAttachedTo.givenDoorSide = DoorSide.right;
        }
        return gameObjectWhichScriptAttachedTo;
    }
    Vector3 Direction;

    void Start()
    {
        if((givenDoorSide == DoorSide.right && !doorStatus) || (givenDoorSide == DoorSide.left && doorStatus))
        {
            Direction = Vector3.right;
        }
        else
        {
            Direction = Vector3.left;
        }
        StartCoroutine(movingDoor());
    }

    IEnumerator movingDoor()
    {
        float timer = 0f;
        float end = opWidth;
        while(timer < end)
        {
            transform.Translate(Direction*Time.deltaTime);
            timer += Time.deltaTime;
        }    
        yield return null;
        Destroy(this);
    }

}
