using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    public Transform trackedObject;
    public float MaxDistance = 10;
    public float moveSpeed = 20;
    public float updateSpeed = 10;
    
    [Range(0,10)]
    public float currentDistance=5;

    private string moveAxis = "Mouse ScrollWheel";
    private GameObject ahead;
    private MeshRenderer _renderer;
    public float hideDistance = 1.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        ahead = new GameObject("ahead");
        _renderer = trackedObject.gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        ahead.transform.position = trackedObject.position + trackedObject.forward * (MaxDistance * 0.25f);
        currentDistance += Input.GetAxisRaw(moveAxis) * moveSpeed * Time.deltaTime;
        currentDistance = Mathf.Clamp(currentDistance, 0, MaxDistance);
        transform.position = Vector3.MoveTowards(transform.position, trackedObject.position + Vector3.up * currentDistance - trackedObject.forward* (currentDistance + MaxDistance * 0.5f), updateSpeed * Time.deltaTime);
        transform.LookAt(ahead.transform);
        _renderer.enabled=(currentDistance > hideDistance);
    }
}
