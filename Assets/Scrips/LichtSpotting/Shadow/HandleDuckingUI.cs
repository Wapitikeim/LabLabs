using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HandleDuckingUI : MonoBehaviour
{
    private RawImage _refImage;
    private Player_Duck _refDuck;

    void Start()
    {
        _refImage = GameObject.Find("DuckingSymbol").GetComponentInChildren<RawImage>();
        _refImage.enabled = false;
        _refDuck = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Duck>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_refDuck.GetIsDucking())
        {
            _refImage.enabled = true;
        }
        else
        {
            _refImage.enabled = false;
        }
    }

}
