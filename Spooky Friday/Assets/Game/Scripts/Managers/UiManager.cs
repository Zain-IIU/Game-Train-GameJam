using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;

public class UiManager : MonoSingleton<UiManager>
{
    [SerializeField] GameObject gameTitle;
    [SerializeField] GameObject[] panelLevelComplete;
    [SerializeField] GameObject[] panelFailed;

    [SerializeField] private RectTransform fadeImage;
    [SerializeField] private float fadeDuration;
    private void Start()
    {
        fadeImage.DOScale(Vector2.zero, fadeDuration).SetEase(Ease.InSine);
    }

    public void EndFade()
    {
        fadeImage.DOScale(Vector2.one * 30f, fadeDuration).SetEase(Ease.OutSine).OnComplete(() =>
        {
            //Load the next level
            SceneManager.LoadScene("Level 1");
        });
    }
  

    



}
