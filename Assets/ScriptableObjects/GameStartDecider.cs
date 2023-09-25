using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameStartDecider : ScriptableObject
{
    private string _gameMode = "Shadow";

    public void SetStartingGameMode (string x)
    {
        _gameMode = x;
    }

    public string GetStartingGameMode()
    {
        return _gameMode;
    }

}
