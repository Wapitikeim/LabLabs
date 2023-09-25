using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class ArchitektonBuilder : MonoBehaviour
{
    public void cleanUpAndArchitektonBuildage(Vector3 spawnPos, Vector3 dim, int maxDepth, Vector2 heightVariationPercentage, bool randomiseHeightOfChildren, float cornerShrinkPercentage, bool activateCorners, bool allowBoxesOnBoxes, Vector2 childLengthWidthFactor, bool randomiseDimensionsofAllChildren)
    {
        cleanupTransformChilds();
        architektonBuilder(spawnPos,dim,maxDepth, heightVariationPercentage, randomiseHeightOfChildren, cornerShrinkPercentage, activateCorners, allowBoxesOnBoxes, childLengthWidthFactor, randomiseDimensionsofAllChildren);
    }
    public void cleanupTransformChilds()
    {
        for(var i = transform.childCount; i > 0; i--)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
    }
    private void architektonBuilder(Vector3 spawnPos, Vector3 dim, int maxDepth, Vector2 heightVariationPercentage, bool randomiseHeightOfChildren, float cornerShrinkPercentage, bool activateCorners, bool allowBoxesOnBoxes, Vector2 childLengthWidthFactor, bool randomiseDimensionsofAllChildren)
    {
        BuildingBoxes.buildSimpleBoxAtPosition(spawnPos, dim, "Parent", transform);
        
        List<Vector3> parentPositions = new List<Vector3>();
        List<Vector3> parentDimensions = new List<Vector3>();
        parentPositions.Add(spawnPos);
        parentDimensions.Add(dim);
        List<Vector3> childPositions = new List<Vector3>();
        List<Vector3> childDimensions = new List<Vector3>();

        while(maxDepth > 0)
        {
            List<List<Vector3>> parentChildRelationship = new List<List<Vector3>>();
            
            //Parents produce childs
            foreach (Vector3 parentPos in parentPositions)
            {
                Vector3 parentdim = parentDimensions[parentPositions.IndexOf(parentPos)];
                
                List<Vector3> parentToChildList = new List<Vector3>();
                parentToChildList.Add(parentPos);
                parentToChildList.Add(parentdim);

                Vector3 childDim;
                childDim.x = parentdim.x * childLengthWidthFactor.x;
                childDim.y = parentdim.y * .5f;
                childDim.z = parentdim.z * childLengthWidthFactor.y;
                float childDimYOriginal = childDim.y;
                childDim.y = childDim.y * Random.Range(heightVariationPercentage.x,heightVariationPercentage.y);
                
                //Left
                Vector3 childPosLeft = PositionCalculationForChildBoxes.calcSpawnPosLeft(parentPos,parentdim, childDim);
                childPositions.Add(childPosLeft);
                childDimensions.Add(childDim);
                parentToChildList.Add(childPosLeft);
                parentToChildList.Add(childDim);
                
                if(randomiseHeightOfChildren)
                {
                    childDim.y = childDimYOriginal * Random.Range(heightVariationPercentage.x,heightVariationPercentage.y);
                }
                if(randomiseDimensionsofAllChildren)
                {
                    childDim.x = parentdim.x * childLengthWidthFactor.x;
                    childDim.z = parentdim.z * childLengthWidthFactor.y;
                }
                //Up
                Vector3 childPosUp = PositionCalculationForChildBoxes.calcSpawnPosUp(parentPos,parentdim, childDim);
                childPositions.Add(childPosUp);
                childDimensions.Add(childDim);
                parentToChildList.Add(childPosUp);
                parentToChildList.Add(childDim);

                if(randomiseHeightOfChildren)
                {
                    childDim.y = childDimYOriginal * Random.Range(heightVariationPercentage.x,heightVariationPercentage.y);
                }
                if(randomiseDimensionsofAllChildren)
                {
                    childDim.x = parentdim.x * childLengthWidthFactor.x;
                    childDim.z = parentdim.z * childLengthWidthFactor.y;
                }
                
                //Right
                Vector3 childPosRight = PositionCalculationForChildBoxes.calcSpawnPosRight(parentPos,parentdim, childDim);
                childPositions.Add(childPosRight);
                childDimensions.Add(childDim);
                parentToChildList.Add(childPosRight);
                parentToChildList.Add(childDim);

                if(randomiseHeightOfChildren)
                {
                    childDim.y = childDimYOriginal * Random.Range(heightVariationPercentage.x,heightVariationPercentage.y);
                }
                if(randomiseDimensionsofAllChildren)
                {
                    childDim.x = parentdim.x * childLengthWidthFactor.x;
                    childDim.z = parentdim.z * childLengthWidthFactor.y;
                }
                
                //Down
                Vector3 childPosDown = PositionCalculationForChildBoxes.calcSpawnPosDown(parentPos,parentdim, childDim);
                childPositions.Add(childPosDown);
                childDimensions.Add(childDim);
                parentToChildList.Add(childPosDown);
                parentToChildList.Add(childDim);

                parentChildRelationship.Add(parentToChildList);
            }

            parentDimensions = new List<Vector3>();
            parentPositions = new List<Vector3>();

            //Childs become Parents
            foreach (Vector3 childPosition in childPositions)
            {
                Vector3 childDim = childDimensions[childPositions.IndexOf(childPosition)];

                if(!CollisionChecker.checkIfBoxCollidesOnPosition(childPosition, childDim))
                {
                    BuildingBoxes.buildSimpleBoxAtPosition(childPosition,childDim,"Child in Depth" + maxDepth, transform);
                    parentPositions.Add(childPosition);
                    parentDimensions.Add(childDim);

                    //Boxes ontop of childs
                    if(allowBoxesOnBoxes)
                    {    
                        Vector3 childPositionOnTop = childPosition;
                        childPositionOnTop.y += childDim.y;

                        Vector3 childDimensionOnTop = childDim/2;
                        //childDimensionOnTop.y = dim.y - Mathf.Abs(Random.Range(childDim.y, (spawnPos.y - childPosition.y)));

                        childPositionOnTop.x += Random.Range(0,childDimensionOnTop.x);
                        childPositionOnTop.z += Random.Range(0, childDimensionOnTop.z);

                        if(!CollisionChecker.checkIfBoxCollidesOnPosition(childPositionOnTop, childDimensionOnTop))
                        {
                            BuildingBoxes.buildSimpleBoxAtPosition(childPositionOnTop, childDimensionOnTop, "BoxOnTop in Depth " + maxDepth, transform);
                        }
                    }
                }
            }

            childPositions = new List<Vector3>();
            childDimensions = new List<Vector3>();

            //ParentInRelationToChilds
            if(activateCorners)
            {
                foreach (List<Vector3> parentChildList in parentChildRelationship)
                {
                    Vector3 currentParentPosition = parentChildList[0];
                    Vector3 currentParentDimension = parentChildList[1];

                    
                    //Left
                    Vector3 currentChildPositionLeft = parentChildList[2];
                    Vector3 currentChildDimLeft = parentChildList[3];
                    //Left corners
                    if(parentPositions.Contains(currentChildPositionLeft)&& parentDimensions.Contains(currentChildDimLeft))
                    {
                        Vector3 cornerPosLeftUp = CornerPositionCalculation.calcCornerPositionLeftUp(currentParentPosition, currentParentDimension, currentChildDimLeft, currentChildPositionLeft);
                        Vector3[] cornerLeftUpTripleBox =
                        (
                            CornerPositionCalculation.calcThreeBoxPositionAndDimensionsFromCorner(
                                CornerPositionCalculation.calcCornerMaxDimPositionLeftUp(currentParentPosition, currentParentDimension, currentChildDimLeft, currentChildPositionLeft),
                                cornerPosLeftUp,
                                new Vector2(1,0),
                                cornerShrinkPercentage
                            )
                        );
                        for (int i = 0; i < 3; i++)
                        {
                            if(i == 0)
                            {
                                if(!CollisionChecker.checkIfBoxCollidesOnPosition(cornerLeftUpTripleBox[i], cornerLeftUpTripleBox[3]) && CollisionChecker.checkIfBoxCollidesOnPositionWithoutTouching(cornerLeftUpTripleBox[i], cornerLeftUpTripleBox[3]))
                                {
                                    BuildingBoxes.buildSimpleBoxAtPosition(cornerLeftUpTripleBox[i], cornerLeftUpTripleBox[3], "cornerBoxLeftUpParent in Depth " + maxDepth, transform);
                                } 
                            }
                            else
                            {
                                if(!CollisionChecker.checkIfBoxCollidesOnPosition(cornerLeftUpTripleBox[i], cornerLeftUpTripleBox[4]) && CollisionChecker.checkIfBoxCollidesOnPositionWithoutTouching(cornerLeftUpTripleBox[i], cornerLeftUpTripleBox[4]))
                                {
                                    BuildingBoxes.buildSimpleBoxAtPosition(cornerLeftUpTripleBox[i], cornerLeftUpTripleBox[4], "cornerBoxLeftUpchild in Depth " + maxDepth, transform);
                                }         
                            }
                        }
                                        
                        Vector3 cornerPosLeftDown = CornerPositionCalculation.calcCornerPositionLeftDown(currentParentPosition, currentChildDimLeft, currentChildPositionLeft);
                        Vector3[] cornerLeftDownTripleBox =
                        (
                            CornerPositionCalculation.calcThreeBoxPositionAndDimensionsFromCorner(
                                CornerPositionCalculation.calcCornerMaxDimPositionLeftDown(currentParentPosition, currentChildDimLeft, currentChildPositionLeft),
                                cornerPosLeftDown,
                                new Vector2(1,1),
                                cornerShrinkPercentage
                            )
                        );
                        for (int i = 0; i < 3; i++)
                        {
                            if(i == 0)
                            {
                                if(!CollisionChecker.checkIfBoxCollidesOnPosition(cornerLeftDownTripleBox[i], cornerLeftDownTripleBox[3]) && CollisionChecker.checkIfBoxCollidesOnPositionWithoutTouching(cornerLeftDownTripleBox[i], cornerLeftDownTripleBox[3]))
                                {
                                    BuildingBoxes.buildSimpleBoxAtPosition(cornerLeftDownTripleBox[i], cornerLeftDownTripleBox[3], "cornerLeftDownParent in Depth " + maxDepth, transform);
                                } 
                            }
                            else
                            {
                                if(!CollisionChecker.checkIfBoxCollidesOnPosition(cornerLeftDownTripleBox[i], cornerLeftDownTripleBox[4]) && CollisionChecker.checkIfBoxCollidesOnPositionWithoutTouching(cornerLeftDownTripleBox[i], cornerLeftDownTripleBox[4]))
                                {
                                    BuildingBoxes.buildSimpleBoxAtPosition(cornerLeftDownTripleBox[i], cornerLeftDownTripleBox[4], "cornerLeftDownChild in Depth " + maxDepth, transform);
                                }         
                            }
                        }
                    }
                    
                    //UP
                    Vector3 currentChildPositionUp = parentChildList[4];
                    Vector3 currentChildDimUp = parentChildList[5];
                    //UP corners
                    if(parentPositions.Contains(currentChildPositionUp)&& parentDimensions.Contains(currentChildDimUp))
                    {
                        Vector3 cornerPosUpLeft = CornerPositionCalculation.calcCornerPositionUpLeft(currentParentPosition, currentParentDimension, currentChildDimUp, currentChildPositionUp);
                        Vector3[] cornerUpLeftTripleBox =
                        (
                            CornerPositionCalculation.calcThreeBoxPositionAndDimensionsFromCorner(
                                CornerPositionCalculation.calcCornerMaxDimPositionUpLeft(currentParentPosition, currentParentDimension, currentChildDimUp, currentChildPositionUp),
                                cornerPosUpLeft,
                                new Vector2(1,0),
                                cornerShrinkPercentage
                            )
                        );
                        for (int i = 0; i < 3; i++)
                        {
                            if(i == 0)
                            {
                                if(!CollisionChecker.checkIfBoxCollidesOnPosition(cornerUpLeftTripleBox[i], cornerUpLeftTripleBox[3]) && CollisionChecker.checkIfBoxCollidesOnPositionWithoutTouching(cornerUpLeftTripleBox[i], cornerUpLeftTripleBox[3]))
                                {
                                    BuildingBoxes.buildSimpleBoxAtPosition(cornerUpLeftTripleBox[i], cornerUpLeftTripleBox[3], "cornerUpLeftParent in Depth " + maxDepth, transform);
                                } 
                            }
                            else
                            {
                                if(!CollisionChecker.checkIfBoxCollidesOnPosition(cornerUpLeftTripleBox[i], cornerUpLeftTripleBox[4])&& CollisionChecker.checkIfBoxCollidesOnPositionWithoutTouching(cornerUpLeftTripleBox[i], cornerUpLeftTripleBox[4]))
                                {
                                    BuildingBoxes.buildSimpleBoxAtPosition(cornerUpLeftTripleBox[i], cornerUpLeftTripleBox[4], "cornerUpLeftchild in Depth " + maxDepth, transform);
                                }         
                            }
                        }
                        Vector3 cornerPosUpRight = CornerPositionCalculation.calcCornerPositionUpRight(currentParentPosition, currentParentDimension, currentChildDimUp, currentChildPositionUp);
                        Vector3[] cornerUpRightTripleBox =
                        (
                            CornerPositionCalculation.calcThreeBoxPositionAndDimensionsFromCorner(
                                CornerPositionCalculation.calcCornerMaxDimPositionUpRight(currentParentPosition, currentParentDimension, currentChildDimUp, currentChildPositionUp),
                                cornerPosUpRight,
                                new Vector2(0,0),
                                cornerShrinkPercentage
                            )
                        );
                        for (int i = 0; i < 3; i++)
                        {
                            if(i == 0)
                            {
                                if(!CollisionChecker.checkIfBoxCollidesOnPosition(cornerUpRightTripleBox[i], cornerUpRightTripleBox[3]) && CollisionChecker.checkIfBoxCollidesOnPositionWithoutTouching(cornerUpRightTripleBox[i], cornerUpRightTripleBox[3]))
                                {
                                    BuildingBoxes.buildSimpleBoxAtPosition(cornerUpRightTripleBox[i], cornerUpRightTripleBox[3], "cornerUpRightParent in Depth " + maxDepth, transform);
                                } 
                            }
                            else
                            {
                                if(!CollisionChecker.checkIfBoxCollidesOnPosition(cornerUpRightTripleBox[i], cornerUpRightTripleBox[4]) && CollisionChecker.checkIfBoxCollidesOnPositionWithoutTouching(cornerUpRightTripleBox[i], cornerUpRightTripleBox[4]))
                                {
                                    BuildingBoxes.buildSimpleBoxAtPosition(cornerUpRightTripleBox[i], cornerUpRightTripleBox[4], "cornerUpRightchild in Depth " + maxDepth, transform);
                                }         
                            }
                        }
                    }
                    
                    //Right
                    Vector3 currentChildPositionRight = parentChildList[6];
                    Vector3 currentChildDimRight = parentChildList[7];
                    //Right Corners
                    if(parentPositions.Contains(currentChildPositionRight)&& parentDimensions.Contains(currentChildDimRight))
                    {
                        Vector3 cornerPosRightUp = CornerPositionCalculation.calcCornerPositionRightUp(currentParentPosition, currentParentDimension, currentChildDimRight, currentChildPositionRight);
                        Vector3[] cornerRightUpTripleBox =
                        (
                            CornerPositionCalculation.calcThreeBoxPositionAndDimensionsFromCorner(
                                CornerPositionCalculation.calcCornerMaxDimPositionRightUp(currentParentPosition, currentParentDimension, currentChildDimRight, currentChildPositionRight),
                                cornerPosRightUp,
                                new Vector2(0,0),
                                cornerShrinkPercentage
                            )
                        );
                        for (int i = 0; i < 3; i++)
                        {
                            if(i == 0)
                            {
                                if(!CollisionChecker.checkIfBoxCollidesOnPosition(cornerRightUpTripleBox[i], cornerRightUpTripleBox[3])&& CollisionChecker.checkIfBoxCollidesOnPositionWithoutTouching(cornerRightUpTripleBox[i], cornerRightUpTripleBox[3]))
                                {
                                    BuildingBoxes.buildSimpleBoxAtPosition(cornerRightUpTripleBox[i], cornerRightUpTripleBox[3], "cornerRightUpParent in Depth " + maxDepth, transform);
                                } 
                            }
                            else
                            {
                                if(!CollisionChecker.checkIfBoxCollidesOnPosition(cornerRightUpTripleBox[i], cornerRightUpTripleBox[4])&& CollisionChecker.checkIfBoxCollidesOnPositionWithoutTouching(cornerRightUpTripleBox[i], cornerRightUpTripleBox[4]))
                                {
                                    BuildingBoxes.buildSimpleBoxAtPosition(cornerRightUpTripleBox[i], cornerRightUpTripleBox[4], "cornerRightUpchild in Depth " + maxDepth, transform);
                                }         
                            }
                        }
                        Vector3 cornerPosRightDown = CornerPositionCalculation.calcCornerPositionRightDown(currentParentPosition, currentParentDimension, currentChildDimRight, currentChildPositionRight);
                        Vector3[] cornerRightDownTripleBox =
                        (
                            CornerPositionCalculation.calcThreeBoxPositionAndDimensionsFromCorner(
                                CornerPositionCalculation.calcCornerMaxDimPositionRightDown(currentParentPosition, currentParentDimension, currentChildDimRight, currentChildPositionRight),
                                cornerPosRightDown,
                                new Vector2(0,1),
                                cornerShrinkPercentage
                            )
                        );
                        for (int i = 0; i < 3; i++)
                        {
                            if(i == 0)
                            {
                                if(!CollisionChecker.checkIfBoxCollidesOnPosition(cornerRightDownTripleBox[i], cornerRightDownTripleBox[3])&& CollisionChecker.checkIfBoxCollidesOnPositionWithoutTouching(cornerRightDownTripleBox[i], cornerRightDownTripleBox[3]))
                                {
                                    BuildingBoxes.buildSimpleBoxAtPosition(cornerRightDownTripleBox[i], cornerRightDownTripleBox[3], "cornerRightDownParent in Depth " + maxDepth, transform);
                                } 
                            }
                            else
                            {
                                if(!CollisionChecker.checkIfBoxCollidesOnPosition(cornerRightDownTripleBox[i], cornerRightDownTripleBox[4])&& CollisionChecker.checkIfBoxCollidesOnPositionWithoutTouching(cornerRightDownTripleBox[i], cornerRightDownTripleBox[4]))
                                {
                                    BuildingBoxes.buildSimpleBoxAtPosition(cornerRightDownTripleBox[i], cornerRightDownTripleBox[4], "cornerRightDownchild in Depth " + maxDepth, transform);
                                }         
                            }
                        }
                    }
                    
                    //Down
                    Vector3 currentChildPositionDown = parentChildList[8];
                    Vector3 currentChildDimDown = parentChildList[9];
                    //Down Corners
                    if(parentPositions.Contains(currentChildPositionDown)&& parentDimensions.Contains(currentChildDimDown))
                    {
                        Vector3 cornerPosDownRight = CornerPositionCalculation.calcCornerPositionDownRight(currentParentPosition,currentParentDimension, currentChildDimDown,currentChildPositionDown);
                        Vector3[] cornerDownRightTripleBox = 
                        (
                            CornerPositionCalculation.calcThreeBoxPositionAndDimensionsFromCorner
                            (
                                CornerPositionCalculation.calcCornerMaxDimPositionDownRight(currentParentPosition,currentParentDimension,currentChildDimDown, currentChildPositionDown),
                                cornerPosDownRight,
                                new Vector3(0,1),
                                cornerShrinkPercentage
                            )
                        );
                        for (int i = 0; i < 3; i++)
                        {
                            if(i == 0)
                            {
                                if(!CollisionChecker.checkIfBoxCollidesOnPosition(cornerDownRightTripleBox[i], cornerDownRightTripleBox[3])&& CollisionChecker.checkIfBoxCollidesOnPositionWithoutTouching(cornerDownRightTripleBox[i], cornerDownRightTripleBox[3]))
                                {
                                    BuildingBoxes.buildSimpleBoxAtPosition(cornerDownRightTripleBox[i], cornerDownRightTripleBox[3], "cornerDownRightParent in Depth " + maxDepth, transform);
                                } 
                            }
                            else
                            {
                                if(!CollisionChecker.checkIfBoxCollidesOnPosition(cornerDownRightTripleBox[i], cornerDownRightTripleBox[4])&& CollisionChecker.checkIfBoxCollidesOnPositionWithoutTouching(cornerDownRightTripleBox[i], cornerDownRightTripleBox[4]))
                                {
                                    BuildingBoxes.buildSimpleBoxAtPosition(cornerDownRightTripleBox[i], cornerDownRightTripleBox[4], "cornerDownRightchild in Depth " + maxDepth, transform);
                                }         
                            }
                        }
                        Vector3 cornerPosDownLeft = CornerPositionCalculation.calcCornerPositionDownLeft(currentParentPosition,currentParentDimension, currentChildDimDown,currentChildPositionDown);
                        Vector3[] cornerDownLeftTripleBox = 
                        (
                            CornerPositionCalculation.calcThreeBoxPositionAndDimensionsFromCorner
                            (
                                CornerPositionCalculation.calcCornerMaxDimPositionDownLeft(currentParentPosition,currentParentDimension,currentChildDimDown, currentChildPositionDown),
                                cornerPosDownLeft,
                                new Vector3(1,1),
                                cornerShrinkPercentage
                            )
                        );
                        for (int i = 0; i < 3; i++)
                        {
                            if(i == 0)
                            {
                                if(!CollisionChecker.checkIfBoxCollidesOnPosition(cornerDownLeftTripleBox[i], cornerDownLeftTripleBox[3])&& CollisionChecker.checkIfBoxCollidesOnPositionWithoutTouching(cornerDownLeftTripleBox[i], cornerDownLeftTripleBox[3]))
                                {
                                    BuildingBoxes.buildSimpleBoxAtPosition(cornerDownLeftTripleBox[i], cornerDownLeftTripleBox[3], "cornerDownLeftParent in Depth " + maxDepth, transform);
                                } 
                            }
                            else
                            {
                                if(!CollisionChecker.checkIfBoxCollidesOnPosition(cornerDownLeftTripleBox[i], cornerDownLeftTripleBox[4])&& CollisionChecker.checkIfBoxCollidesOnPositionWithoutTouching(cornerDownLeftTripleBox[i], cornerDownLeftTripleBox[4]))
                                {
                                    BuildingBoxes.buildSimpleBoxAtPosition(cornerDownLeftTripleBox[i], cornerDownLeftTripleBox[4], "cornerDownLeftchild in Depth " + maxDepth, transform);
                                }         
                            }
                        }
                    }
            }
            }

            maxDepth--;
        }

}

}