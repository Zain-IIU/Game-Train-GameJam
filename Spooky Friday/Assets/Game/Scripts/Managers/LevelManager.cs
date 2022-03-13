using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoSingleton<LevelManager>
{
    [SerializeField] private string sceneToLoad;
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    
    public void RestartLevel()
    {
        Debug.Log("Restart the level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    private void OnDisable()
    {
        DOTween.KillAll();
    }
}
