using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalRoom : MonoBehaviour
{
    public Transform _targetPortalRoom;

    private SimpleMovement _refScript;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _refScript = GameObject.FindGameObjectWithTag("Player").GetComponent<SimpleMovement>();
    }

    void OnTriggerEnter(Collider _col)
    {
        if(_col.tag == "Player")
        {
            _refScript.SetPosition(_targetPortalRoom.position);
        }
    }
}
