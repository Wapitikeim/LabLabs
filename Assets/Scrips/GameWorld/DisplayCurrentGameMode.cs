using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayCurrentGameMode : MonoBehaviour
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
        _refText.text = _refGP.getCurGPType();
    }
}
