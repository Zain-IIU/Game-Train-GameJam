﻿using System;
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
    [SerializeField] private CanvasGroup endCredits;
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

    [SerializeField] private AudioSource bgSource;
    
    public void ShowEndCredits()
    {
        CameraManager.instance.ZoomCamera(20f);
        endCredits.gameObject.SetActive(true);
        DOTween.To(() => endCredits.alpha, x => endCredits.alpha = x, 1f, 1f);
        bgSource.volume = 0.05f;
        AudioManager.instance.Play("Pass");
    }
  

    



}
