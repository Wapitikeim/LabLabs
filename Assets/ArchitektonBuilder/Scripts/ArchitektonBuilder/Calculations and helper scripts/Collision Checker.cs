using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public static class CollisionChecker 
{
    public  static bool checkIfBoxCollidesOnPosition(Vector3 position, Vector3 boxDimensions)
    {  
        //Could be written inside the boxInterference Definition but this will (hopefully) make it clear on the spot
        Vector3 centerBoxPosition = new Vector3(position.x + boxDimensions.x/2, position.y + boxDimensions.y/2, position.z + boxDimensions.z/2);
        
        //The *0.99f is there because we allow "touching" boxes otherwise it wont work properly
        Collider[] boxInterference = Physics.OverlapBox(centerBoxPosition,(boxDimensions/2)*0.99f, Quaternion.identity, 1 , QueryTriggerInteraction.Collide);

        if(boxInterference.Length == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
        
    }

    public  static bool checkIfBoxCollidesOnPositionWithoutTouching(Vector3 position, Vector3 boxDimensions)
    {  
        //Could be written inside the boxInterference Definition but this will (hopefully) make it clear on the spot
        Vector3 centerBoxPosition = new Vector3(position.x + boxDimensions.x/2, position.y + boxDimensions.y/2, position.z + boxDimensions.z/2);
        
        Collider[] boxInterference = Physics.OverlapBox(centerBoxPosition,(boxDimensions/2), Quaternion.identity, 1 , QueryTriggerInteraction.Collide);

        if(boxInterference.Length == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
        
    }


}
