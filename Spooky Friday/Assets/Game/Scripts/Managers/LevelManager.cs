using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoSingleton<LevelManager>
{
    public void LoadNextLevel()
    {
        int nextLevelIndex = SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCount - 1
            ? 0
            : SceneManager.GetActiveScene().buildIndex + 1;

        Debug.Log("Loading scene at index "+nextLevelIndex);
        SceneManager.LoadScene(nextLevelIndex);
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
