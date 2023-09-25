using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LightTimer : MonoBehaviour
{
    private float _currentTimerTime = 90f;
    private float _timerStartingTime;

    private bool _activateTimer = false;

    private TextMeshProUGUI _refText;


    void Awake()
    {
        _refText = GetComponent<TextMeshProUGUI>();
        _refText.enabled = false;
    }

    void Update()
    {
      
       if (_activateTimer && _currentTimerTime > 0)
       {
           _currentTimerTime -= Time.deltaTime;
           _refText.text = Mathf.FloorToInt(_currentTimerTime).ToString();
       }
       else if (_activateTimer && _currentTimerTime < 0)
       {
           _activateTimer = false;
           _refText.enabled = false;
            ResetPlayer();
       }
       
    }
    

    public void ActivateTimer(float _newMaxTimer)
    {
        _refText.enabled = true;
        _currentTimerTime = _newMaxTimer;
        int _refStatus = GameObject.Find("GameMecStatus").GetComponent<GameMecStatus>().getStatus();
        if(_refStatus > 1)
        {
            float _adjustedMaxTimer = _newMaxTimer + ((float)_refStatus * 5) - 5;
            _currentTimerTime = _adjustedMaxTimer;
        }
        _activateTimer = true;
    }
    
    private void ResetPlayer()
    {
        GameObject _player = GameObject.FindGameObjectWithTag("Player");
        GameMecStatus _gpIncrease = GameObject.Find("GameMecStatus").GetComponent<GameMecStatus>();
        _gpIncrease.increaseStatus();

        CheckpointSystem _cpSystem = GameObject.Find("CheckPointSystem").GetComponent<CheckpointSystem>();
        SimpleMovement _spmPlayer = _player.GetComponent<SimpleMovement>();

        _spmPlayer.SetPosition(_cpSystem.getPos());
        _spmPlayer.SetRotation(_cpSystem.getRot());
    }

    public void DisableTimer()
    {
        _activateTimer = false;
        _activateTimer = false;
        _refText.enabled = false;
    }

    //Setter
    public void SetCurrentTimerTime(float x)
    {
        _currentTimerTime = x;
    }

    public void SetTimerStartingTime(float x)
    {
        _timerStartingTime = x;
    }

    public void StopTimer(bool x)
    {
        _activateTimer = x;
    }

    //Getter
    public float GetCurrentTimerTime()
    {
        return _currentTimerTime;
    }

}
