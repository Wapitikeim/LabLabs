using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchitektonController : MonoBehaviour
{
    //Public
    public int iterationDepth = 4;
    public Vector3 initialBoxDimensions = new Vector3(1,1,1);

    public Vector2 heightRandomiserMinMax = new Vector2(1.5f,2f);

    public bool recursiveWithCoroutine = true;

    public bool iterative = false;

    //Private
    private Vector3 defaultSpawnPosition = new Vector3(0,0,0);

    private List<Vector3> cornerPointList = new List<Vector3>();
    

    void Start()
    {
        if(recursiveWithCoroutine && !iterative)
        {
            StartCoroutine(rekursiveCoroutineAlgorithm(iterationDepth, defaultSpawnPosition, initialBoxDimensions));
        }
        if(!recursiveWithCoroutine && iterative)
        {
            anotherIterativeAlgorithm(iterationDepth, new Vector3(0,0,0), initialBoxDimensions);
        }

    }

    //Recursive (Coroutine)
    public IEnumerator rekursiveCoroutineAlgorithm(int currentIterationDepth, Vector3 spawnPosition, Vector3 boxDimensions)
    {
        
        if(currentIterationDepth > 0)
        {
            if(currentIterationDepth == iterationDepth)
            {
                buildSimpleBoxAtPosition(spawnPosition,boxDimensions, "Parent");
            }
            else
            {
                buildSimpleBoxAtPosition(spawnPosition,boxDimensions, "Child in Depth: " + currentIterationDepth);
            }
            
            //Height Variation
            Vector3 newBoxDimensionsForAllDirections = calculateHeightVariation(boxDimensions);
            
            //calculate newBoxPositions for Every Side;
            Vector3[] newBoxPositions = new Vector3[4];
            newBoxPositions = calculateBoxPositionsWithRandomRange(spawnPosition,boxDimensions,newBoxDimensionsForAllDirections);

            //handle recursive branching
            StartCoroutine(handleBranchingDepthFirstForEverySideWithCollisionCheckCoroutine(currentIterationDepth,newBoxPositions,newBoxDimensionsForAllDirections));
        
        }
        else if(currentIterationDepth <= 0)
        {
            yield return null;
        }
        
    }

    private IEnumerator handleBranchingDepthFirstForEverySideWithCollisionCheckCoroutine(int currentIterationDepth, Vector3[] newBoxPositions, Vector3 newBoxDimension)
    {
        //hier muss erneut kurz gewartet werden weil die Collision sonst nicht zuverlässig funktioniert
        yield return new WaitForFixedUpdate();
        if(!CollisionChecker.checkIfBoxCollidesOnPosition(newBoxPositions[0],newBoxDimension))
        {
            yield return rekursiveCoroutineAlgorithm(currentIterationDepth -1, newBoxPositions[0], newBoxDimension);
        }
        yield return new WaitForFixedUpdate();  
        if(!CollisionChecker.checkIfBoxCollidesOnPosition(newBoxPositions[1],newBoxDimension))
        {
            yield return rekursiveCoroutineAlgorithm(currentIterationDepth -1, newBoxPositions[1], newBoxDimension);
        }
        yield return new WaitForFixedUpdate();    
        if(!CollisionChecker.checkIfBoxCollidesOnPosition(newBoxPositions[2],newBoxDimension))
        {
            yield return rekursiveCoroutineAlgorithm(currentIterationDepth -1, newBoxPositions[2], newBoxDimension);
        }
        yield return new WaitForFixedUpdate();    
        if(!CollisionChecker.checkIfBoxCollidesOnPosition(newBoxPositions[3],newBoxDimension))
        {
            yield return rekursiveCoroutineAlgorithm(currentIterationDepth -1, newBoxPositions[3], newBoxDimension);
        }
        
        yield return null;

    }

    //Iterative 
    private IEnumerator iterativeArchitektonAlgorithm(int maxIterationDepth, Vector3 spawnPosition, Vector3 parentBoxDimension)
    {
        //Brutally brute forced -> NEEDS to change but it works for now
        buildSimpleBoxAtPosition(spawnPosition,parentBoxDimension, "Parent");
        Vector3 refSpawnPos = spawnPosition;
        int refIterationDepth = maxIterationDepth;
        Vector3 refParentBoxDimenions = parentBoxDimension;
        while(maxIterationDepth > 0)
        {
            //Height Variation
            Vector3 newBoxDimensionsForAllDirections = calculateHeightVariation(parentBoxDimension);

            //calculate newBoxPositions for Every Side;
            Vector3[] newBoxPositions = new Vector3[4];
            newBoxPositions = calculateBoxPositionsWithRandomRange(spawnPosition,parentBoxDimension,newBoxDimensionsForAllDirections);

            StartCoroutine(handleBoxBuildageInEveryDirectionWithCollisionCheck(maxIterationDepth - 1, newBoxPositions, newBoxDimensionsForAllDirections));
            yield return new WaitForFixedUpdate();

            maxIterationDepth = maxIterationDepth - 1;
            parentBoxDimension = newBoxDimensionsForAllDirections;
            spawnPosition = newBoxPositions[0];
        }
        spawnPosition = refSpawnPos;
        maxIterationDepth = refIterationDepth;
        parentBoxDimension = refParentBoxDimenions;
        while(maxIterationDepth > 0)
        {
            //Height Variation
            Vector3 newBoxDimensionsForAllDirections = calculateHeightVariation(parentBoxDimension);

            //calculate newBoxPositions for Every Side;
            Vector3[] newBoxPositions = new Vector3[4];
            newBoxPositions = calculateBoxPositionsWithRandomRange(spawnPosition,parentBoxDimension,newBoxDimensionsForAllDirections);

            StartCoroutine(handleBoxBuildageInEveryDirectionWithCollisionCheck(maxIterationDepth - 1, newBoxPositions, newBoxDimensionsForAllDirections));
            yield return new WaitForFixedUpdate();

            maxIterationDepth = maxIterationDepth - 1;
            parentBoxDimension = newBoxDimensionsForAllDirections;
            spawnPosition = newBoxPositions[1];
        }
        spawnPosition = refSpawnPos;
        maxIterationDepth = refIterationDepth;
        parentBoxDimension = refParentBoxDimenions;
        while(maxIterationDepth > 0)
        {
            //Height Variation
            Vector3 newBoxDimensionsForAllDirections = calculateHeightVariation(parentBoxDimension);

            //calculate newBoxPositions for Every Side;
            Vector3[] newBoxPositions = new Vector3[4];
            newBoxPositions = calculateBoxPositionsWithRandomRange(spawnPosition,parentBoxDimension,newBoxDimensionsForAllDirections);

            StartCoroutine(handleBoxBuildageInEveryDirectionWithCollisionCheck(maxIterationDepth - 1, newBoxPositions, newBoxDimensionsForAllDirections));
            yield return new WaitForFixedUpdate();

            maxIterationDepth = maxIterationDepth - 1;
            parentBoxDimension = newBoxDimensionsForAllDirections;
            spawnPosition = newBoxPositions[2];
        }
        spawnPosition = refSpawnPos;
        maxIterationDepth = refIterationDepth;
        parentBoxDimension = refParentBoxDimenions;
        while(maxIterationDepth > 0)
        {
            //Height Variation
            Vector3 newBoxDimensionsForAllDirections = calculateHeightVariation(parentBoxDimension);

            //calculate newBoxPositions for Every Side;
            Vector3[] newBoxPositions = new Vector3[4];
            newBoxPositions = calculateBoxPositionsWithRandomRange(spawnPosition,parentBoxDimension,newBoxDimensionsForAllDirections);

            StartCoroutine(handleBoxBuildageInEveryDirectionWithCollisionCheck(maxIterationDepth - 1, newBoxPositions, newBoxDimensionsForAllDirections));
            yield return new WaitForFixedUpdate();

            maxIterationDepth = maxIterationDepth - 1;
            parentBoxDimension = newBoxDimensionsForAllDirections;
            spawnPosition = newBoxPositions[3];
        }

        yield return null;
        
/*         foreach (Vector3 cornerPos in cornerPointList)
        {
            GameObject cornerSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            cornerSphere.transform.position = cornerPos;
            cornerSphere.transform.localScale *= 0.01f;
            cornerSphere.GetComponent<SphereCollider>().enabled = false;
        } */
    }

    private IEnumerator handleBoxBuildageInEveryDirectionWithCollisionCheck(int currentIterationDepth, Vector3[] newBoxPositions, Vector3 newBoxDimension)
    {
        //hier muss erneut kurz gewartet werden weil die Collision sonst nicht zuverlässig funktioniert
        yield return new WaitForEndOfFrame();
        if(!CollisionChecker.checkIfBoxCollidesOnPosition(newBoxPositions[0],newBoxDimension))
        {
            buildSimpleBoxAtPosition(newBoxPositions[0], newBoxDimension, "Child in Depth: " + currentIterationDepth);
        }
        
        if(!CollisionChecker.checkIfBoxCollidesOnPosition(newBoxPositions[1],newBoxDimension))
        {
            buildSimpleBoxAtPosition(newBoxPositions[1], newBoxDimension, "Child in Depth: " + currentIterationDepth);
        }
            
        if(!CollisionChecker.checkIfBoxCollidesOnPosition(newBoxPositions[2],newBoxDimension))
        {
            buildSimpleBoxAtPosition(newBoxPositions[2], newBoxDimension, "Child in Depth: " + currentIterationDepth);
        }
           
        if(!CollisionChecker.checkIfBoxCollidesOnPosition(newBoxPositions[3],newBoxDimension))
        {
            buildSimpleBoxAtPosition(newBoxPositions[3], newBoxDimension, "Child in Depth: " + currentIterationDepth);
        }
        yield return 1;
    }

    //HelpFunctions
    private void buildSimpleBoxAtPosition(Vector3 spawnPosition, Vector3 boxDimensions, string boxname)
    {
        GameObject boxToCreate = new GameObject(boxname);
        boxToCreate.transform.parent = transform;
        boxToCreate.AddComponent<CreateSimpleMeshBox>();
        boxToCreate.GetComponent<CreateSimpleMeshBox>().CreateSimpleBox(spawnPosition, boxDimensions);

    }

    private Vector3 calculateHeightVariation(Vector3 boxDimension)
    {
        float currentVariation = Random.RandomRange(heightRandomiserMinMax.x, heightRandomiserMinMax.y);

        return boxDimension/currentVariation;
    }

    private Vector3[] calculateBoxPositionsWithRandomRange(Vector3 currentPosition, Vector3 oldBoxDimensions, Vector3 newBoxDimensions)
    {
        Vector3[] combinedPositions = new Vector3[4];
        
        /* Vector3 newBoxPositionLeft = PositionCalculationForSymmetricalPlacements.calculateNewSpawnPositionLeft(currentPosition,oldBoxDimensions,newBoxDimensions); */
        Vector3 newBoxPositionLeft = PositionCalculationForChildBoxes.calcSpawnPosLeft(currentPosition, oldBoxDimensions, newBoxDimensions);
        combinedPositions[0] = newBoxPositionLeft;

        /* Vector3 newBoxPositionRight = PositionCalculationForSymmetricalPlacements.calculateNewSpawnPositionRight(currentPosition,oldBoxDimensions,newBoxDimensions); */
        Vector3 newBoxPositionRight = PositionCalculationForChildBoxes.calcSpawnPosRight(currentPosition, oldBoxDimensions, newBoxDimensions);
        combinedPositions[1] = newBoxPositionRight;

        /* Vector3 newBoxPositionTop = PositionCalculationForSymmetricalPlacements.calculateNewSpawnPositionTop(currentPosition,oldBoxDimensions,newBoxDimensions); */
        Vector3 newBoxPositionUp = PositionCalculationForChildBoxes.calcSpawnPosUp(currentPosition, oldBoxDimensions, newBoxDimensions);
        combinedPositions[2] = newBoxPositionUp;
        
        /* Vector3 newBoxPositionBottom = PositionCalculationForSymmetricalPlacements.calculateNewSpawnPositionBottom(currentPosition,oldBoxDimensions,newBoxDimensions); */
        Vector3 newBoxPositionDown = PositionCalculationForChildBoxes.calcSpawnPosDown(currentPosition, oldBoxDimensions, newBoxDimensions);
        combinedPositions[3] = newBoxPositionDown;
        
        return combinedPositions;
    }

    
    //New Iterative Approach

    public void anotherIterativeAlgorithm(int maxDepth, Vector3 parentSpawnPosition, Vector3 parentBoxDimension)
    {
        buildSimpleBoxAtPosition(parentSpawnPosition,parentBoxDimension, "Parent");
        
        List<Vector3> PositionsToBuildNext = new List<Vector3>();
        Vector3 newBoxDimension = calculateHeightVariation(parentBoxDimension);
        Vector3[] PositionsToAdd = calculateBoxPositionsWithRandomRange(parentSpawnPosition, parentBoxDimension, newBoxDimension);
        PositionsToBuildNext.Add(PositionsToAdd[0]);
        PositionsToBuildNext.Add(PositionsToAdd[1]);
        PositionsToBuildNext.Add(PositionsToAdd[2]);
        PositionsToBuildNext.Add(PositionsToAdd[3]);

        while(maxDepth >= 0)
        {
            List<Vector3> PositionsToKeep = new List<Vector3>();
            foreach (Vector3 entry in PositionsToBuildNext)
            {
                if(!CollisionChecker.checkIfBoxCollidesOnPosition(entry, newBoxDimension))
                {
                    buildSimpleBoxAtPosition(entry, newBoxDimension, "Child in Depth: " + maxDepth);
                    PositionsToKeep.Add(entry);
                } 
            }
            List<Vector3> NextPositions = new List<Vector3>();
            foreach (Vector3 entry in PositionsToKeep)
            {
                Vector3 currentBoxDimension = newBoxDimension;
                newBoxDimension = calculateHeightVariation(newBoxDimension);
                PositionsToAdd = calculateBoxPositionsWithRandomRange(entry, currentBoxDimension, newBoxDimension);
                NextPositions.Add(PositionsToAdd[0]);
                NextPositions.Add(PositionsToAdd[1]);
                NextPositions.Add(PositionsToAdd[2]);
                NextPositions.Add(PositionsToAdd[3]);
            }


            PositionsToBuildNext = new List<Vector3>();
            foreach (Vector3 entry in NextPositions)
            {
                PositionsToBuildNext.Add(entry);
            }
            
            maxDepth -= 1;
        }

    }
    


}
