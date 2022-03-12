using DG.Tweening;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class DialogueManager : MonoSingleton<DialogueManager>
{
    [SerializeField] private TextMeshProUGUI dialogueToDisplay;

    [SerializeField] private RectTransform dialogueBox;

    [SerializeField] private float easeTime;
    [SerializeField] private Ease easeType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ShowDialogue(string textToShow)
    {
        dialogueBox.DOScale(Vector3.one, easeTime).SetEase(easeType).OnComplete(()=>
        {
            dialogueToDisplay.text = textToShow;
        });
    }

}
