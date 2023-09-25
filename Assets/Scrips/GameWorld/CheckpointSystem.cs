using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSystem : MonoBehaviour
{
    private Vector3 _pos;

    private string _raum;

    private Quaternion _playerRot;

    void Awake()
    {
        _pos = GameObject.FindGameObjectWithTag("Player").transform.position;
        _playerRot = GameObject.FindGameObjectWithTag("Player").transform.rotation;
        _raum = "Raum1";
    }

//Setter

    public void setPos(Vector3 _newPos)
    {
        _pos = _newPos;
    }

    public void setRaum(string _newRaum)
    {
        _raum = _newRaum;
    }

    public void setRot(Quaternion _newRot)
    {
        _playerRot = _newRot;
    }


//Getter
    public Vector3 getPos()
    {
        return _pos;
    }

    public string getRaum()
    {
        return _raum;
    }

    public Quaternion getRot()
    {
        return _playerRot;
    }
}
