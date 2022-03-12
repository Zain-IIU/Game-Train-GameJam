using DG.Tweening;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class DialogueManager : MonoSingleton<DialogueManager>
{ 
    private TextMeshProUGUI dialogueToDisplay;

    private RectTransform dialogueBox;

    [SerializeField] private float easeTime;
    [SerializeField] private Ease easeType;

  

    public void ShowDialogue(string textToShow,bool toShow)
    {
        if (toShow)
        {
            dialogueBox.DOScale(Vector3.one, easeTime).SetEase(easeType).OnComplete(()=>
            {
                dialogueToDisplay.text = textToShow;
            });
        }
        else
        {
            dialogueBox.DOScale(Vector3.zero, easeTime).SetEase(easeType).OnComplete(()=>
            {
                dialogueToDisplay.text = "";
            });
        }
        
       
    }

    public void SetPanels(TextMeshProUGUI textBox, RectTransform dBox)
    {
        dialogueToDisplay = textBox;
        dialogueBox = dBox;
    }

}
