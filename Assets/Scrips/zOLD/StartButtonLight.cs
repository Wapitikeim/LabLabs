using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class StartButtonLight : MonoBehaviour
{
       public Button _startButtonLight;

    void Start()
    {
        Button btn = _startButtonLight.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("LabLabs_Light");
    }
}
