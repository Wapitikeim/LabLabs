using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class QuitButtonPauseMenu : MonoBehaviour
{
    public Button _quitButton;

    private PauseMenu _refScript;

    void Start()
    {
        
        Button _btn = _quitButton.GetComponent<Button>();
        _refScript = GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<PauseMenu>();
        _btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        _refScript.QuitGame();
    }
}
