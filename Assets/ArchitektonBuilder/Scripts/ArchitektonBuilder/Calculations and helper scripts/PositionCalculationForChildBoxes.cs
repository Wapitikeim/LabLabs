using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PositionCalculationForChildBoxes 
{
    //Uses RandomRange (0, maxPossible)
    public static Vector3 calcSpawnPosLeft(Vector3 parentPos, Vector3 parentDim, Vector3 childDim)
    {
        Vector3 childPos;
        childPos.x = parentPos.x - childDim.x;
        childPos.y = parentPos.y;
        childPos.z = parentPos.z + ((parentDim.z-childDim.z) - Random.Range(0,(parentDim.z-childDim.z)));

        return childPos;
    }

    public static Vector3 calcSpawnPosRight(Vector3 parentPos, Vector3 parentDim, Vector3 childDim)
    {
        Vector3 childPos;
        childPos.x = parentPos.x + parentDim.x;
        childPos.y = parentPos.y;
        childPos.z = parentPos.z + ((parentDim.z-childDim.z) - Random.Range(0,(parentDim.z-childDim.z)));

        return childPos;
    }

    public static Vector3 calcSpawnPosUp(Vector3 parentPos, Vector3 parentDim, Vector3 childDim)
    {
        Vector3 childPos;
        childPos.x = parentPos.x + ((parentDim.x - childDim.x) - Random.Range(0,(parentDim.x - childDim.x)));
        childPos.y = parentPos.y;
        childPos.z = parentPos.z + parentDim.z;

        return childPos;
    }

    public static Vector3 calcSpawnPosDown(Vector3 parentPos, Vector3 parentDim, Vector3 childDim)
    {
        Vector3 childPos;
        childPos.x = parentPos.x + ((parentDim.x - childDim.x) - Random.Range(0,(parentDim.x - childDim.x)));
        childPos.y = parentPos.y;
        childPos.z = parentPos.z - childDim.z;

        return childPos;
    }


}
