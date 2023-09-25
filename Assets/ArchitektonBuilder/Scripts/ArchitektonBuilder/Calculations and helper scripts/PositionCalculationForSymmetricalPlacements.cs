using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PositionCalculationForSymmetricalPlacements 
{
    public static Vector3 calculateNewSpawnPositionLeft(Vector3 currentPosition, Vector3 oldBoxDimensions, Vector3 newBoxDimensions)
    {
        Vector3 newSpawnPosition = currentPosition;
        
        newSpawnPosition.x = newSpawnPosition.x - newBoxDimensions.x;
        newSpawnPosition.z = newSpawnPosition.z + (oldBoxDimensions.z/2 - (newBoxDimensions.z/2));
        
        return newSpawnPosition;
    }

    public static Vector3 calculateNewSpawnPositionRight(Vector3 currentPosition, Vector3 oldBoxDimensions, Vector3 newBoxDimensions)
    {
        Vector3 newSpawnPosition = currentPosition;
        
        newSpawnPosition.x = newSpawnPosition.x + oldBoxDimensions.x;
        newSpawnPosition.z = newSpawnPosition.z + (oldBoxDimensions.z/2 - (newBoxDimensions.z/2));
        
        return newSpawnPosition;
    }

    public static Vector3 calculateNewSpawnPositionTop(Vector3 currentPosition, Vector3 oldBoxDimensions, Vector3 newBoxDimensions)
    {
        Vector3 newSpawnPosition = currentPosition;
        
        newSpawnPosition.x = newSpawnPosition.x + (oldBoxDimensions.x/2 - (newBoxDimensions.x/2));
        newSpawnPosition.z = newSpawnPosition.z + oldBoxDimensions.z;
        
        return newSpawnPosition;
    }

    public static Vector3 calculateNewSpawnPositionBottom(Vector3 currentPosition, Vector3 oldBoxDimensions, Vector3 newBoxDimensions)
    {
        Vector3 newSpawnPosition = currentPosition;
        
        newSpawnPosition.x = newSpawnPosition.x + (oldBoxDimensions.x/2 - (newBoxDimensions.x/2));
        newSpawnPosition.z = newSpawnPosition.z - newBoxDimensions.z;
        
        return newSpawnPosition;
    }


}
