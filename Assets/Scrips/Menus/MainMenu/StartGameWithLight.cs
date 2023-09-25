using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class StartGameWithLight : MonoBehaviour
{
    public GameStartDecider _gameStartGP;
    public Button _startButton;



    void Start()
    {
        
        Button btn = _startButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        _gameStartGP.SetStartingGameMode("Light");
        SceneManager.LoadScene("LabLabs");
    }
}
