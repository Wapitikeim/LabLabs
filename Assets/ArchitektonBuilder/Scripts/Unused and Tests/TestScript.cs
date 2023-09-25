using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public float width = 1;
    public float height = 1;
    // Start is called before the first frame update
    void Start()
    {
        //print("LetsGo");


        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));

        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();

        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[4]
        {
            new Vector3(0, 0, 0),
            new Vector3(width, 0, 0),
            new Vector3(0, height, 0),
            new Vector3(width, height, 0)
        };
        mesh.vertices = vertices;

        int[] tris = new int[6]
        {
            // lower left triangle
            0, 2, 1,
            // upper right triangle
            2, 3, 1
        };
        mesh.triangles = tris;

        Vector3[] normals = new Vector3[4]
        {
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward
        };
        mesh.normals = normals;

        Vector2[] uv = new Vector2[4]
        {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(1, 1)
        };
        mesh.uv = uv;

        meshFilter.mesh = mesh;
    
    }

    // Update is called once per frame
    void Update()
    {
        /*
    IEnumerator boxesPerHand()
    {
        
        GameObject box1 = new GameObject("box1");
        box1.transform.parent = transform;
        box1.AddComponent<CreateSimpleMeshBox>();
        yield return new WaitForSeconds(0.1f);
        box1.GetComponent<CreateSimpleMeshBox>().CreateSimpleBox(new Vector3(0,0,0), new Vector3(1,1,1));

        GameObject box2 = new GameObject("box2");
        box2.transform.parent = transform;
        box2.AddComponent<CreateSimpleMeshBox>();
        yield return new WaitForSeconds(0.1f);
        box2.GetComponent<CreateSimpleMeshBox>().CreateSimpleBox(new Vector3(-1,0,0), new Vector3(3,2,3));

        GameObject box3 = new GameObject("box3");
        box3.transform.parent = transform;
        box3.AddComponent<CreateSimpleMeshBox>();
        yield return new WaitForSeconds(0.1f);
        box3.GetComponent<CreateSimpleMeshBox>().CreateSimpleBox(new Vector3(0,0,1), new Vector3(1,2,1));


        GameObject box4 = new GameObject("box4");
        box4.transform.parent = transform;
        box4.AddComponent<CreateSimpleMeshBox>();
        yield return new WaitForSeconds(0.1f);
        box4.GetComponent<CreateSimpleMeshBox>().CreateSimpleBox(new Vector3(-1.5f,0,0), new Vector3(0.5f,1,0.5f));

        GameObject box5 = new GameObject("box5");
        box5.transform.parent = transform;
        box5.AddComponent<CreateSimpleMeshBox>();
        yield return new WaitForSeconds(0.1f);
        box5.GetComponent<CreateSimpleMeshBox>().CreateSimpleBox(new Vector3(-0.5f,0,1), new Vector3(0.5f,1,0.5f));

        GameObject box6 = new GameObject("box6");
        box6.transform.parent = transform;
        box6.AddComponent<CreateSimpleMeshBox>();
        yield return new WaitForSeconds(0.1f);
        box6.GetComponent<CreateSimpleMeshBox>().CreateSimpleBox(new Vector3(0.5f,0,2), new Vector3(0.5f,0.8f,.5f));





    }
    */
    }
}
