using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ExitToMenuPauseMenu : MonoBehaviour
{
    public Button _exitToMenuButton;

    private PauseMenu _refScript;

    void Start()
    {
        
        Button btn = _exitToMenuButton.GetComponent<Button>();
        _refScript = GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<PauseMenu>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        _refScript.ReturnToMainMenu();
    }
}
