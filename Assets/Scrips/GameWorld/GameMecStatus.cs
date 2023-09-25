using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMecStatus : MonoBehaviour
{
    //Scriptable Ref 
    public GameStartDecider _gameStartGP;
    
    private int _status = 1;

    //Should be even
    public int _statusThreshold = 4;

    private string _currentGPType;
    private string _startingGPType;

    private Transform[] _allGPLight;
    private Transform[] _allGPShadow;
    
    
    void Start()
    {
        _allGPLight = GameObject.Find("GPLight").transform.GetComponentsInChildren<Transform>();
        _allGPShadow = GameObject.Find("GPShadow").transform.GetComponentsInChildren<Transform>();
        _startingGPType = _gameStartGP.GetStartingGameMode();
        _currentGPType = _startingGPType;
        ChangeGP();
    }



    public void increaseStatus()
    {
        
        if((_status+1) > _statusThreshold)
        {
            _status = 1;
            _currentGPType = _startingGPType;
            ChangeGP();
        }
        else
        {
            _status += 1;
        }
       
        if(_status == _statusThreshold)
        {
            if(_startingGPType.Equals("Shadow"))
            {
                _currentGPType = "Light";
            }
            else 
            {
                _currentGPType = "Shadow";
            }
            ChangeGP();
        }
    }

    private void ChangeGP()
    {
        if (_currentGPType.Equals("Light"))
        {
            _allGPShadow[0].gameObject.SetActive(false);
            _allGPLight[0].gameObject.SetActive(true);
            adjustGPMechanic();
            
        }
        else if(_currentGPType.Equals("Shadow"))
        {
            _allGPShadow[0].gameObject.SetActive(true);
            _allGPLight[0].gameObject.SetActive(false);
            adjustGPMechanic();
        }
    }

    private void adjustGPMechanic ()
    {
        if(_currentGPType.Equals("Light"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player_ControlGravity>().enabled = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player_NewDash>().enabled = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Duck>().enabled = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Duck>().RewindDuckingIfDuck();
            
        }
        else if (_currentGPType.Equals("Shadow"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player_ControlGravity>().enabled = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<SimpleMovement>().SetEnableGravity(true);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player_NewDash>().enabled = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Duck>().enabled = true;
        }
        
    }

    //Setter
    public void setGP(string _newMode)
    {
        if (_newMode.Equals("Light"))
        {
            _currentGPType = "Light";
            _status = 1;
        }
        else if (_newMode.Equals("Shadow"))
        {
            _currentGPType = "Shadow";
            _status = _statusThreshold / 2 + 1;
        }
        else
        {
            print("Wrong Input for GP Change!");
        }
        ChangeGP();
    }

    public void setStatus(int x)
    {
        _status = x;
    }

    public void resetStatus()
    {
        _status = 1;
    }
    //Getter
    public int getStatus()
    {
        return _status;
    }

    public string getCurGPType()
    {
        return _currentGPType;
    }

    public string getStartingGP()
    {
        return _startingGPType;
    }
}
