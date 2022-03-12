using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    void Start()
    {
        Application.targetFrameRate = 60;
    }
  

}