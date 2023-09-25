using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public static class BuildingBoxes
{
    public static void buildSimpleBoxAtPosition(Vector3 spawnPosition, Vector3 boxDimensions, string boxname)
    {
        GameObject boxToCreate = new GameObject(boxname);
        boxToCreate.AddComponent<CreateSimpleMeshBox>();
        boxToCreate.GetComponent<CreateSimpleMeshBox>().CreateSimpleBox(spawnPosition, boxDimensions);
    }

    public static void buildSimpleBoxAtPosition(Vector3 spawnPosition, Vector3 boxDimensions, string boxname, Transform transformToAttachTo)
    {
        GameObject boxToCreate = new GameObject(boxname);
        boxToCreate.transform.parent = transformToAttachTo;
        boxToCreate.AddComponent<CreateSimpleMeshBox>();
        boxToCreate.GetComponent<CreateSimpleMeshBox>().CreateSimpleBox(spawnPosition, boxDimensions);
    }
}
