using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableWalls : MonoBehaviour
{
    public float openingWidth = 0.75f;

    public bool open = false;

    private Transform LeftSideTF;
    private Transform RightSideTF;

    private GameObject LeftSideGO;
    private GameObject RightSideGO;


    void Start()
    {
        LeftSideTF = transform.GetChild(0);
        RightSideTF = transform.GetChild(1);

        LeftSideGO = LeftSideTF.gameObject;
        RightSideGO = RightSideTF.gameObject;
    }

    public void initiateOpeningProzess()
    {
        Destroy(LeftSideGO.GetComponent<MoveIndividualDoor>());
        MoveIndividualDoor.CreateScriptForDoor(LeftSideGO,openingWidth,open);
        Destroy(RightSideGO.GetComponent<MoveIndividualDoor>());
        MoveIndividualDoor.CreateScriptForDoor(RightSideGO,openingWidth,open);
        open = !open;
    }

}
