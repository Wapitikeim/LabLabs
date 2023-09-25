using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayCurrentGameModeStatus : MonoBehaviour
{
    private GameMecStatus _refGP;
    private TextMeshProUGUI _refText;

    void Awake()
    {
        _refGP = GameObject.Find("GameMecStatus").GetComponent<GameMecStatus>();
        _refText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if(_refGP.getCurGPType().Equals(_refGP.getStartingGP()))
        {
            _refText.text = "Current attempt: " +_refGP.getStatus() + "/" + (_refGP._statusThreshold-1).ToString();
        }
        else
        {
            _refText.text = "Current attempt:  1/1";
        }
    }
}
