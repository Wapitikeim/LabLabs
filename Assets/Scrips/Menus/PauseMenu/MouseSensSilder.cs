using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MouseSensSilder : MonoBehaviour
{
    
    CameraLookup _refCL;
    Slider _refSlider;

    void Start()
    {
        _refCL = GameObject.Find("FPSCamera").GetComponent<CameraLookup>();
        _refSlider = GetComponent<Slider>();
    }

    public void SetMouseSens ()
    {
        _refCL.SetMouseSensitivity(_refSlider.value);
    }
}
