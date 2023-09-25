using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TriggerBoxColliderInteraction : MonoBehaviour
{
    private Vector3 _playerPos;
    private GameObject _player;
    
    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter(Collider Trigger)
    {
        if(Trigger.tag == "Player")
        {
            handleInteraction();
        }
    }

    private void handleInteraction()
    {
        GameMecStatus _gpIncrease = GameObject.Find("GameMecStatus").GetComponent<GameMecStatus>();
        _gpIncrease.increaseStatus();

        CheckpointSystem _cpSystem = GameObject.Find("CheckPointSystem").GetComponent<CheckpointSystem>();
        SimpleMovement _spmPlayer = _player.GetComponent<SimpleMovement>();

        _spmPlayer.SetPosition(_cpSystem.getPos());
        _spmPlayer.SetRotation(_cpSystem.getRot());
    }
}
