using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Duck : MonoBehaviour
{
    private Vector3 _defaultScale;
    private GameObject _refPlayer;

    private bool _isDucking = false;

    private float _duckChange;
    
    void Start()
    {
        _refPlayer = GameObject.FindGameObjectWithTag("Player");
        _defaultScale = _refPlayer.transform.localScale;
        _duckChange = 0.5f;
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl) && _refPlayer.transform.localScale == _defaultScale)
        {
            _refPlayer.transform.localScale -= new Vector3(0,_duckChange,0);
            _isDucking = true;
        }
        else if(Input.GetKeyDown(KeyCode.LeftControl) && _refPlayer.transform.localScale != _defaultScale)
        {
            _refPlayer.transform.localScale = _defaultScale;
            _isDucking = false;
        }
    }

    public void RewindDuckingIfDuck()
    {
        if(_isDucking)
        {
            _refPlayer.transform.localScale = _defaultScale;
            _isDucking = false;
        }
    }
    
    public bool GetIsDucking()
    {
        return _isDucking;
    }


}
