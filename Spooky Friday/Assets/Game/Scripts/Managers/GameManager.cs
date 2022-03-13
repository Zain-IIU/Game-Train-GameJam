using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoSingleton<GameManager>
{
    void Start()
    {
        Application.targetFrameRate = 60;
    }
  

}