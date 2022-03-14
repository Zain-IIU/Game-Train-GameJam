using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class StoryTelling : MonoBehaviour
{
    [Multiline] [SerializeField] private string[] scripts;

    [SerializeField] private TextMeshProUGUI storyText;

    [SerializeField] private int curTextIndex;

    [SerializeField] private CanvasGroup storyCanvas;

    [SerializeField] private RectTransform buttons;

    [SerializeField] private RectTransform playButton;

    [SerializeField] private AudioSource source;

    [SerializeField] private AudioClip[] clips;

    [SerializeField] private RectTransform inputCheck;


    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("showInputDialog"))
            PlayerPrefs.SetInt("showInputDialog",0);
        else
        {
            StartNaration();
            UpdateText();
        }
        
        
        if(!PlayerPrefs.HasKey("isMouse"))
            PlayerPrefs.SetInt("isMouse",0);
        curTextIndex = 0;
        
        if (PlayerPrefs.GetInt("showInputDialog") == 0)
        {
            PlayerPrefs.SetInt("showInputDialog",1);
            inputCheck.DOScale(Vector2.one, 0.25f);
        }
    }

    private void StartNaration()
    {
        DOTween.To(() => storyCanvas.alpha, x => storyCanvas.alpha = x, 1f, 1f).OnComplete(() =>
        {
            buttons.gameObject.SetActive(true);
        });
    }
    public void UpdateText()
    {
        AudioManager.instance.Play("Press");
        AudioManager.instance.PlaySoundWithAudioSource(source,clips[curTextIndex]);
        buttons.DOScaleY(0, 0.5f);
        if (curTextIndex == scripts.Length - 1)
        {
            buttons.DOScale(Vector2.zero, 0.5f).OnComplete(() =>
            { 
                playButton.DOScaleY(1, 0.5f);
            });
      
        }
        storyText.DOColor(Color.black, 0.5f).OnComplete(() =>
        {
            storyText.text = scripts[curTextIndex++];
            storyText.DOColor(Color.white, 0.5f);
            buttons.DOScaleY(1, 0.25f);
        });
    }

    public void SelectInputType(bool isMouse)
    {
        AudioManager.instance.Play("Press");
        inputCheck.DOScale(Vector2.zero, 0.24f).OnComplete(() =>
        {
            StartNaration();
            UpdateText();
        });
        PlayerPrefs.SetInt("isMouse", isMouse ? 1 : 0);
    }

}
