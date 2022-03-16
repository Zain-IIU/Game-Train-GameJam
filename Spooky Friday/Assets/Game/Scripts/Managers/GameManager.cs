using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoSingleton<GameManager>
{
    public event Action ONGamePaused;
    void Start()
    {
        Application.targetFrameRate = 60;
    }


    public void OnGamePaused()
    {
        ONGamePaused?.Invoke();
    }
}