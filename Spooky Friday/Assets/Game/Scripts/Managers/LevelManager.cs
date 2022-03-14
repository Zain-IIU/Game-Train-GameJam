using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    [SerializeField] private string sceneToLoad;

    private void Awake()
    {
        instance = this;
    }

    public void LoadNextLevel()
    {
        AudioManager.instance.Play("Press");
        SceneManager.LoadScene(sceneToLoad);
    }
    
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    private void OnDisable()
    {
        DOTween.KillAll();
    }
}
