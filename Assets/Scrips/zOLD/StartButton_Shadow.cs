using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class StartButton_Shadow : MonoBehaviour
{
    public Button _startButtonShadow;

    void Start()
    {
        Button btn = _startButtonShadow.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("LabLabs_Shadow");
    }
}
