using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSimpleQuad : MonoBehaviour
{
    public float breadth = 1;
    public float height = 1;
    public float depth = 1;
    public Vector3 startingPosition = new Vector3(0,0,0);

    
    private MeshRenderer meshRenderer;
    private MeshFilter meshFilter;
    
    
    void Start()
    {
        SetupComponents();
        Vector3 dimensions = new Vector3(breadth,height,depth);
        CreateSimpleBox(startingPosition, dimensions);

        /*
        GameObject testBox = new GameObject();
        testBox.AddComponent<CreateSimpleQuad>();
        testBox.GetComponent<CreateSimpleQuad>().startingPosition = new Vector3(2,2,0);
        */

    }


    private void SetupComponents()
    {
        AttachMeshRenderer();
        
        Material mat = new Material(Shader.Find("Standard"));
        SetMeshRendererSharedMaterial(mat);

        AttachMeshFilter();
    }

    private void AttachMeshRenderer()
    {
        meshRenderer = gameObject.AddComponent<MeshRenderer>();
    }

    private void AttachMeshFilter()
    {
        meshFilter = gameObject.AddComponent<MeshFilter>();
    }

    private void SetMeshRendererSharedMaterial(Material mat)
    {
        meshRenderer.sharedMaterial = mat;
    }

    private void CreateSimpleBox(Vector3 spawnPosition, Vector3 boxDimensions)
    {
        Mesh boxMesh = new Mesh();
        float boxBreadth = boxDimensions.x;
        float boxHeight = boxDimensions.y;
        float boxDepth = boxDimensions.z;
         
        Vector3[] boxVertices = new Vector3[24]
        {
            //General Order of vertices
            //(Left down - Left Up - Right Up - Right down)
            
            //Why 24 not 8 Vetices?
            //->More clear Box apperence
            
            //XZ Bottom 
            spawnPosition,
            new Vector3(spawnPosition.x + boxBreadth, spawnPosition.y, spawnPosition.z ),
            new Vector3(spawnPosition.x + boxBreadth, spawnPosition.y, spawnPosition.z + boxDepth),
            new Vector3(spawnPosition.x, spawnPosition.y ,spawnPosition.z + boxDepth),

            //XZ Top
            new Vector3(spawnPosition.x, spawnPosition.y + boxHeight, spawnPosition.z),
            new Vector3(spawnPosition.x + boxBreadth, spawnPosition.y + boxHeight, spawnPosition.z ),
            new Vector3(spawnPosition.x + boxBreadth, spawnPosition.y + boxHeight, spawnPosition.z + boxDepth),
            new Vector3(spawnPosition.x, spawnPosition.y + boxHeight,spawnPosition.z + boxDepth),

            //YZ Front
            spawnPosition,
            new Vector3(spawnPosition.x, spawnPosition.y + boxHeight, spawnPosition.z),
            new Vector3(spawnPosition.x, spawnPosition.y + boxHeight, spawnPosition.z + boxDepth),
            new Vector3(spawnPosition.x, spawnPosition.y ,spawnPosition.z + boxDepth),

            //YZ Back
            new Vector3(spawnPosition.x + boxBreadth, spawnPosition.y, spawnPosition.z),
            new Vector3(spawnPosition.x + boxBreadth, spawnPosition.y + boxHeight, spawnPosition.z),
            new Vector3(spawnPosition.x + boxBreadth, spawnPosition.y + boxHeight, spawnPosition.z + boxDepth),
            new Vector3(spawnPosition.x + boxBreadth, spawnPosition.y ,spawnPosition.z + boxDepth),

            //XY Left
            spawnPosition,
            new Vector3(spawnPosition.x, spawnPosition.y + boxHeight, spawnPosition.z),
            new Vector3(spawnPosition.x + boxBreadth, spawnPosition.y + boxHeight, spawnPosition.z ),
            new Vector3(spawnPosition.x + boxBreadth, spawnPosition.y, spawnPosition.z),

            //XY Right
            new Vector3(spawnPosition.x, spawnPosition.y, spawnPosition.z + boxDepth),
            new Vector3(spawnPosition.x, spawnPosition.y + boxHeight, spawnPosition.z + boxDepth),
            new Vector3(spawnPosition.x + boxBreadth, spawnPosition.y + boxHeight, spawnPosition.z + boxDepth ),
            new Vector3(spawnPosition.x + boxBreadth, spawnPosition.y, spawnPosition.z + boxDepth),
        };
     
        int [] boxTriangels = new int[36]
        {
            //XZ Bottom
            0,1,3,
            1,2,3,

            //XZ Top
            7,5,4,
            7,6,5,

            //YZ Front
            11,9,8,
            11,10,9,

            //YZ Back
            12,13,15,
            13,14,15,

            //XY Left
            16,17,19,
            17,18,19,

            //XY Right 
            23,21,20,
            23,22,21,
        };
        
        Vector3 [] boxNormals = new Vector3[24]
        {
            //XZ Bottom
            Vector3.down,
            Vector3.down,
            Vector3.down,
            Vector3.down,

            //XZ Top
            Vector3.up,
            Vector3.up,
            Vector3.up,
            Vector3.up,

            //YZ Front
            Vector3.back,
            Vector3.back,
            Vector3.back,
            Vector3.back,

            //YZ Back
            Vector3.forward,
            Vector3.forward,
            Vector3.forward,
            Vector3.forward,

            //XY Left
            Vector3.left,
            Vector3.left,
            Vector3.left,
            Vector3.left,

            //XY Right
            Vector3.right,
            Vector3.right,
            Vector3.right,
            Vector3.right,
        };
        
        Vector2[] boxUV = new Vector2[24]
        {
            //Bottom
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(1, 1),
            new Vector2(0, 1),

            //Top
            new Vector2(-0, -0),
            new Vector2(-1, -0),
            new Vector2(-1, -1),
            new Vector2(-0, -1),

            //YZ Front
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(1, 1),
            new Vector2(0, 1),

            //YZ Back
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(1, 1),
            new Vector2(0, 1),

            //XY Left
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(1, 1),
            new Vector2(0, 1),

            //XY Right
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(1, 1),
            new Vector2(0, 1),
        };
             
        boxMesh.vertices = boxVertices;
        boxMesh.triangles = boxTriangels;
        boxMesh.normals = boxNormals;
        boxMesh.uv = boxUV;
        
        meshFilter.mesh = boxMesh;


    }

}
