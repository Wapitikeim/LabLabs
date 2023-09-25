using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class VersionTextField : MonoBehaviour
{
    private Text _versionText;

    void Awake()
    {
        _versionText = GetComponent<Text>();
        _versionText.text = "V " + Application.version;
    } 
}
