using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private BoxCollider _col;

    public string _raum;

    public float _LightTimer = 60f;

    public bool _stopTimer = false;


    void Awake()
    {
        if(GetComponent<BoxCollider>())
        {
            _col = GetComponent<BoxCollider>();
        }
        else
        {
            print("No Boxcollider on "+ this.name + " found!");
        }   
    }

    void OnTriggerEnter(Collider Trigger)
    {
        if(Trigger.tag == "Player" && !GameObject.Find("CheckPointSystem").GetComponent<CheckpointSystem>().getRaum().Equals(_raum))
        {
            setCheckpointPosAndRot();
        }
    }

    void OnTriggerExit(Collider Trigger)
    {
        if(Trigger.tag == "Player" && 
        GameObject.Find("CheckPointSystem").GetComponent<CheckpointSystem>().getRaum().Equals(_raum) && 
        GameObject.Find("GameMecStatus").GetComponent<GameMecStatus>().getCurGPType().Equals("Light") )
        {
            GameObject.Find("LightTimerText").GetComponent<LightTimer>().ActivateTimer(_LightTimer);
            //ShouldTimer Stop?
            GameObject.Find("LightTimerText").GetComponent<LightTimer>().StopTimer(!_stopTimer);
        }
    }

    private void setCheckpointPosAndRot()
    {
        CheckpointSystem _refCP = GameObject.Find("CheckPointSystem").GetComponent<CheckpointSystem>();
        _refCP.setPos(GameObject.FindGameObjectWithTag("Player").transform.position);
        _refCP.setRaum(_raum);
        _refCP.setRot(GameObject.FindGameObjectWithTag("Player").transform.rotation);



        string _startGP = GameObject.Find("GameMecStatus").GetComponent<GameMecStatus>().getStartingGP();
        string _curGP = GameObject.Find("GameMecStatus").GetComponent<GameMecStatus>().getCurGPType();

        if (!_curGP.Equals(_startGP))
        {
            GameObject.Find("GameMecStatus").GetComponent<GameMecStatus>().increaseStatus();
            if (_curGP.Equals("Light"))
            {
                GameObject.Find("LightTimerText").GetComponent<LightTimer>().DisableTimer();
            }
        }
        else
        {
            GameObject.Find("GameMecStatus").GetComponent<GameMecStatus>().setStatus(1);
        }


        
        
    }


}
