using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;

public class UiManager : MonoSingleton<UiManager>
{
    [SerializeField] private RectTransform fadeImage;
    [SerializeField] private float fadeDuration;

    [SerializeField] private bool showGuide;
    [SerializeField] private RectTransform tutorialPanel;
    public  bool gameStarted;
    private void Start()
    {
        gameStarted = !showGuide;
        if (showGuide)
            tutorialPanel.DOScale(Vector2.one, 0.25f);
        fadeImage.DOScale(Vector2.zero, fadeDuration).SetEase(Ease.InSine);
    }

    public void EndFade()
    {
        fadeImage.DOScale(Vector2.one * 30f, fadeDuration).SetEase(Ease.OutSine).OnComplete(() =>
        {
            //Load the next level
            LevelManager.instance.LoadNextLevel();
        });
    }
    public void StartFade()
    {
        tutorialPanel.DOScale(Vector2.zero, 0.24f);
        gameStarted = true;
    }
  

    



}
