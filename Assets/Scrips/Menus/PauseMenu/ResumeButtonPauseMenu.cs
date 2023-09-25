using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ResumeButtonPauseMenu : MonoBehaviour
{

    public Button _resumeButton;

    private PauseMenu _refScript;

    void Start()
    {
        
        Button btn = _resumeButton.GetComponent<Button>();
        _refScript = GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<PauseMenu>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        _refScript.Resume();
    }
}
