using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour
{
    public Transform TrackedObject;
    public float updateSpeed = 3;
    public Vector2 trackingOffset;
    private Vector3 offset;
    
        void Start()
    {
        offset = (Vector3)trackingOffset;
        offset.z = transform.position.z - TrackedObject.position.z;
    }

    // Update is called once per frame
    void LaneUpdate()
    {
        
    }
}
