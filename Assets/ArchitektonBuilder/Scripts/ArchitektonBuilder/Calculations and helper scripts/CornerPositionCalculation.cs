using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CornerPositionCalculation 
{
    public static Vector3[] calcThreeBoxPositionAndDimensionsFromCorner(Vector3 maxDimensions, Vector3 cornerSpawnPosition, Vector2 directionIndicator, float shrinkPercentage)
    {
        float childShrinkPercentage = Mathf.Abs((shrinkPercentage)/2);

        Vector3 parentDimension = maxDimensions;
        parentDimension.x = maxDimensions.x * shrinkPercentage;
        parentDimension.y = maxDimensions.y * 0.8f;
        parentDimension.z = maxDimensions.z * shrinkPercentage;

        Vector3 childDimension = maxDimensions;
        childDimension.x = maxDimensions.x * childShrinkPercentage;
        childDimension.y = maxDimensions.y * 0.4f;
        childDimension.z = maxDimensions.z * childShrinkPercentage;

        Vector3 adjustedParentPosition = new Vector3
        (
            (cornerSpawnPosition.x + (directionIndicator.x * (maxDimensions.x - parentDimension.x))),
            cornerSpawnPosition.y,
            (cornerSpawnPosition.z + (directionIndicator.y * (maxDimensions.z - parentDimension.z)))
        );

        Vector3 childLeftPosition = new Vector3(0,0,0);
        Vector3 childRightPosition = new Vector3(0,0,0);
        
        if(directionIndicator == new Vector2(1,1))
        {
            childLeftPosition.x = adjustedParentPosition.x - childDimension.x;
            childLeftPosition.z = adjustedParentPosition.z + (parentDimension.z - childDimension.z);
            childLeftPosition.y = cornerSpawnPosition.y;

            childRightPosition.x = adjustedParentPosition.x + (parentDimension.x - childDimension.x);
            childRightPosition.z = adjustedParentPosition.z - childDimension.z;
            childRightPosition.y = cornerSpawnPosition.y;
        }
        if(directionIndicator == new Vector2(1,0))
        {
            childLeftPosition.x = adjustedParentPosition.x - childDimension.x;
            childLeftPosition.z = adjustedParentPosition.z;
            childLeftPosition.y = cornerSpawnPosition.y;

            childRightPosition.x = adjustedParentPosition.x + (parentDimension.x - childDimension.x);
            childRightPosition.z = adjustedParentPosition.z + parentDimension.z;
            childRightPosition.y = cornerSpawnPosition.y;
        }
        if(directionIndicator == new Vector2(0,1))
        {
            childLeftPosition.x = adjustedParentPosition.x;
            childLeftPosition.z = adjustedParentPosition.z - childDimension.z;
            childLeftPosition.y = cornerSpawnPosition.y;

            childRightPosition.x = adjustedParentPosition.x + parentDimension.x;
            childRightPosition.z = adjustedParentPosition.z + (parentDimension.z - childDimension.z);
            childRightPosition.y = cornerSpawnPosition.y;
        }
        if(directionIndicator == new Vector2(0,0))
        {
            childLeftPosition.x = adjustedParentPosition.x;
            childLeftPosition.z = adjustedParentPosition.z + parentDimension.z;
            childLeftPosition.y = cornerSpawnPosition.y;

            childRightPosition.x = adjustedParentPosition.x + parentDimension.x;
            childRightPosition.z = adjustedParentPosition.z;
            childRightPosition.y = cornerSpawnPosition.y;
        }

        Vector3[] cornerTriplePositions  = new Vector3[5];
        cornerTriplePositions[0] = adjustedParentPosition;
        cornerTriplePositions[1] = childLeftPosition;
        cornerTriplePositions[2] = childRightPosition;
        cornerTriplePositions[3] = parentDimension;
        cornerTriplePositions[4] = childDimension;

        return cornerTriplePositions;
    }

    //Left
    public static Vector3 calcCornerPositionLeftDown(Vector3 parentPos, Vector3 childDim, Vector3 childPos)
    {
        Vector3 cornerPos;
        if(childDim.x >= (childPos.z - parentPos.z))
        {
            cornerPos.x = parentPos.x - (childPos.z - parentPos.z);
            cornerPos.y = parentPos.y;
            cornerPos.z = parentPos.z;
        }
        else
        {
            cornerPos.x = parentPos.x - childDim.x;
            cornerPos.y = parentPos.y;
            cornerPos.z = parentPos.z;
        }
        return cornerPos;
    }
    public static Vector3 calcCornerMaxDimPositionLeftDown(Vector3 parentPos, Vector3 childDim, Vector3 childPos)
    {
        Vector3 MaxDim;
        if(childDim.x >= (childPos.z - parentPos.z))
        {
            MaxDim.x = (childPos.z - parentPos.z);
            MaxDim.y = childDim.y;
            MaxDim.z = (childPos.z - parentPos.z);
        }
        else
        {
            MaxDim.x = childDim.x;
            MaxDim.y = childDim.y;
            MaxDim.z = childDim.x;
        }
        return MaxDim;
    }
    public static Vector3 calcCornerPositionLeftUp(Vector3 parentPos, Vector3 parentDim, Vector3 childDim, Vector3 childPos)
    {
        Vector3 cornerPos;
        if(childDim.x >= (parentDim.z - ((childPos.z - parentPos.z) + childDim.z)))
        {
            cornerPos.x = parentPos.x - (parentDim.z - ((childPos.z - parentPos.z) + childDim.z));
            cornerPos.y = parentPos.y;
            cornerPos.z = parentPos.z + ((childPos.z - parentPos.z) + childDim.z);
        }
        else
        {
            cornerPos.x = parentPos.x - childDim.x;
            cornerPos.y = parentPos.y;
            cornerPos.z = parentPos.z + (childDim.z + (childPos.z - parentPos.z));
        }
        return cornerPos;
    }
    public static Vector3 calcCornerMaxDimPositionLeftUp(Vector3 parentPos, Vector3 parentDim, Vector3 childDim, Vector3 childPos)
    {
        Vector3 MaxDim;
        if(childDim.x >= (parentDim.z - ((childPos.z - parentPos.z) + childDim.z)))
        {
            MaxDim.x = (parentDim.z - ((childPos.z - parentPos.z) + childDim.z));
            MaxDim.y = childDim.y;
            MaxDim.z = (parentDim.z - ((childPos.z - parentPos.z) + childDim.z));
        }
        else
        {
            MaxDim.x = childDim.x;
            MaxDim.y = childDim.y;
            MaxDim.z = childDim.x;
        }
        return MaxDim;
    }
    
    //Up
    public static Vector3 calcCornerPositionUpLeft(Vector3 parentPos, Vector3 parentDim, Vector3 childDim, Vector3 childPos)
    {
        Vector3 cornerPos;
        if(childDim.z >= (childPos.x - parentPos.x))
        {
            cornerPos.x = childPos.x - (childPos.x - parentPos.x);
            cornerPos.y = parentPos.y;
            cornerPos.z = parentDim.z;
        }
        else
        {
            cornerPos.x = childPos.x - childDim.z;
            cornerPos.y = parentPos.y;
            cornerPos.z = parentDim.z;
        }
        return cornerPos;
    }
    public static Vector3 calcCornerMaxDimPositionUpLeft(Vector3 parentPos, Vector3 parentDim, Vector3 childDim, Vector3 childPos)
    {
        Vector3 MaxDim;
        if(childDim.z >= (childPos.x - parentPos.x))
        {
            MaxDim.x = (childPos.x - parentPos.x);
            MaxDim.y = childDim.y;
            MaxDim.z = (childPos.x - parentPos.x);
        }
        else
        {
            MaxDim.x = childDim.z;
            MaxDim.y = childDim.y;
            MaxDim.z = childDim.z;
        }
        return MaxDim;
    }
    public static Vector3 calcCornerPositionUpRight(Vector3 parentPos, Vector3 parentDim, Vector3 childDim, Vector3 childPos)
    {
        Vector3 cornerPos;
        cornerPos.x = childPos.x + childDim.x;
        cornerPos.y = parentPos.y;
        cornerPos.z = parentPos.z + parentDim.z;
        return cornerPos;
    }
    public static Vector3 calcCornerMaxDimPositionUpRight(Vector3 parentPos, Vector3 parentDim, Vector3 childDim, Vector3 childPos)
    {
        Vector3 MaxDim;
        if(childDim.z >= parentDim.x - ((childPos.x - parentPos.x) + childDim.x))
        {
            MaxDim.x = parentDim.x - ((childPos.x - parentPos.x) + childDim.x);
            MaxDim.y = childDim.y;
            MaxDim.z = parentDim.x - ((childPos.x - parentPos.x) + childDim.x);
        }
        else
        {
            MaxDim.x = childDim.z;
            MaxDim.y = childDim.y;
            MaxDim.z = childDim.z;
        }
        return MaxDim;
    }
    
    //Right
    public static Vector3 calcCornerPositionRightUp(Vector3 parentPos, Vector3 parentDim, Vector3 childDim, Vector3 childPos)
    {
        Vector3 cornerPos;
        cornerPos.x = parentPos.x + parentDim.x;
        cornerPos.y = parentPos.y;
        cornerPos.z = childPos.z + childDim.z;
        return cornerPos;
    }
    public static Vector3 calcCornerMaxDimPositionRightUp(Vector3 parentPos, Vector3 parentDim, Vector3 childDim, Vector3 childPos)
    {
        Vector3 MaxDim;
        if(childDim.x >= parentDim.z - ((childPos.z - parentPos.z) + childDim.z))
        {
            MaxDim.x = parentDim.z - ((childPos.z - parentPos.z) + childDim.x);
            MaxDim.y = childDim.y;
            MaxDim.z = parentDim.z - ((childPos.z - parentPos.z) + childDim.x);
        }
        else
        {
            MaxDim.x = childDim.x;
            MaxDim.y = childDim.y;
            MaxDim.z = childDim.x;
        }
        return MaxDim;
    }
    public static Vector3 calcCornerPositionRightDown(Vector3 parentPos, Vector3 parentDim, Vector3 childDim, Vector3 childPos)
    {
        Vector3 cornerPos;
        if(childDim.x >= (childPos.z - parentPos.z))
        {
            cornerPos.x = parentPos.x + parentDim.x;
            cornerPos.y = parentPos.y;
            cornerPos.z = childPos.z - (childPos.z - parentPos.z);
        }
        else
        {
            cornerPos.x = parentPos.x + parentDim.x;
            cornerPos.y = parentPos.y;
            cornerPos.z = childPos.z - childDim.x;
        }
        return cornerPos;
    }
    public static Vector3 calcCornerMaxDimPositionRightDown(Vector3 parentPos, Vector3 parentDim, Vector3 childDim, Vector3 childPos)
    {
        Vector3 MaxDim;
        if(childDim.x >= (childPos.z - parentPos.z))
        {
            MaxDim.x = (childPos.z - parentPos.z);
            MaxDim.y = childDim.y;
            MaxDim.z = (childPos.z - parentPos.z);
        }
        else
        {
            MaxDim.x = childDim.x;
            MaxDim.y = childDim.y;
            MaxDim.z = childDim.x;
        }
        return MaxDim;
    }
    
    //Down
    public static Vector3 calcCornerPositionDownLeft(Vector3 parentPos, Vector3 parentDim, Vector3 childDim, Vector3 childPos)
    {
        Vector3 cornerPos;
        if(childDim.z >= (childPos.x - parentPos.x))
        {
            cornerPos.x = parentPos.x;
            cornerPos.y = parentPos.y;
            cornerPos.z = parentPos.z - (childPos.x - parentPos.x);
        }
        else
        {
            cornerPos.x = childPos.x - childDim.z;
            cornerPos.y = parentPos.y;
            cornerPos.z = childPos.z - childDim.z;
        }
        return cornerPos;
    }
    public static Vector3 calcCornerMaxDimPositionDownLeft(Vector3 parentPos, Vector3 parentDim, Vector3 childDim, Vector3 childPos)
    {
        Vector3 MaxDim;
        if(childDim.z >= (childPos.x - parentPos.x))
        {
            MaxDim.x = (childPos.x - parentPos.x);
            MaxDim.y = childDim.y;
            MaxDim.z = (childPos.x - parentPos.x);
        }
        else
        {
            MaxDim.x = childDim.z;
            MaxDim.y = childDim.y;
            MaxDim.z = childDim.z;
        }
        return MaxDim;
    }
    public static Vector3 calcCornerPositionDownRight(Vector3 parentPos, Vector3 parentDim, Vector3 childDim, Vector3 childPos)
    {
        Vector3 cornerPos;
        if(childDim.z >= parentDim.x - ((childPos.x - parentPos.x)+ childDim.x))
        {
            cornerPos.x = parentPos.x + (childPos.x - parentPos.x) + childDim.x;
            cornerPos.y = parentPos.y;
            cornerPos.z = parentPos.z - (parentDim.x - ((childPos.x - parentPos.x)+ childDim.x));
        }
        else
        {
            cornerPos.x = parentPos.x + (childPos.x - parentPos.x) + childDim.x;;
            cornerPos.y = parentPos.y;
            cornerPos.z = parentPos.z - childDim.z;
        }
        return cornerPos;
    }
    public static Vector3 calcCornerMaxDimPositionDownRight(Vector3 parentPos, Vector3 parentDim, Vector3 childDim, Vector3 childPos)
    {
        Vector3 MaxDim;
        if(childDim.z >= parentDim.x - ((childPos.x - parentPos.x)+ childDim.x))
        {
            MaxDim.x = parentDim.x - ((childPos.x - parentPos.x)+ childDim.x);
            MaxDim.y = childDim.y;
            MaxDim.z = parentDim.x - ((childPos.x - parentPos.x)+ childDim.x);
        }
        else
        {
            MaxDim.x = childDim.z;
            MaxDim.y = childDim.y;
            MaxDim.z = childDim.z;
        }
        return MaxDim;
    }
}
