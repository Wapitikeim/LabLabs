using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_ControlGravity : MonoBehaviour
{
    
    private SimpleMovement _refScript;
    public float _maxAirTime;
    private float _airTimer;
    void Start()
    {
        _refScript = GetComponent<SimpleMovement>();
    }

    
    void Update()
    {
        
        if(Input.GetButton("ActionB") && _airTimer <= _maxAirTime && !_refScript.GetIsGrounded())
        {
           _refScript.SetGravity(false);
        }
        else
        {
            _refScript.SetGravity(true);
        }

        if(_refScript.GetIsGrounded())
        {
            _airTimer = 0;
        }
        else 
        {
            _airTimer += Time.deltaTime;
        }

        
        
    }

}
