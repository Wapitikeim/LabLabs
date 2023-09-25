using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_NewDash : MonoBehaviour
{
    public float _dashSpeed = 1f;
    public float _dashTime = 2f;

    public float _cooldown = 1f;

    private float _cooldTimer = 0f;

    private float _startTime;

    private CharacterController _charContr;

    void Update()
    {
        if(Input.GetButtonDown("ActionB") && _cooldTimer <= 0)
        {
            StartCoroutine(Dash());
        }
        if(_cooldTimer >0)
        {
            _cooldTimer -= Time.deltaTime;
        }
    }

    private IEnumerator Dash()
    {
        _cooldTimer = _cooldown;
        _charContr = GetComponent<CharacterController>();
        float _startTime = Time.time;
        while(Time.time < _startTime + _dashTime)
        {
            
            _charContr.Move(transform.forward * _dashSpeed * Time.deltaTime);
            yield return null;
        }
    }


}
