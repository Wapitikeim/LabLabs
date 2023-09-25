using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloorUpDown : MonoBehaviour
{   
    private float speed;
    private Vector3 targetPosition;

    public void SetSpeed(float spd)
    {
        speed = spd;
    }

    public void SetTargetPosition(Vector3 tPosition)
    {
        targetPosition = tPosition;
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        if(transform.position.Equals(targetPosition) && targetPosition != null)
        {
            Destroy(this);
        }
        
    }

    
}
