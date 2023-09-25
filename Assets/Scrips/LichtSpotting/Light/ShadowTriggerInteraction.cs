using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ShadowTriggerInteraction : MonoBehaviour
{
    void OnTriggerEnter(Collider _trigger)
    {
        if(_trigger.tag == "Player")
        {
            handleInteraction();
        }
    }

    private void handleInteraction()
    {
        GameMecStatus _gpIncrease = GameObject.Find("GameMecStatus").GetComponent<GameMecStatus>();
        _gpIncrease.increaseStatus();

        CheckpointSystem _cpSystem = GameObject.Find("CheckPointSystem").GetComponent<CheckpointSystem>();
        SimpleMovement _spmPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<SimpleMovement>();

        _spmPlayer.SetPosition(_cpSystem.getPos());
        _spmPlayer.SetRotation(_cpSystem.getRot());
    }

}
