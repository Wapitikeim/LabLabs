using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class StartGameButton : MonoBehaviour
{
    public Button _startButton;

    private GameObject _bLight;
    private GameObject _bShadow;

    void Start()
    {
        _bLight = GameObject.Find("B_Start_Game_Light");
        _bLight.SetActive(false);
        _bShadow = GameObject.Find("B_Start_Game_Shadow");
        _bShadow.SetActive(false);
        
        Button btn = _startButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        
        _bLight.SetActive(true);
        _bShadow.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
