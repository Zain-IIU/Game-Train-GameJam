using System;
using System.Diagnostics;
using TMPro.SpriteAssetUtilities;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

public  class Trigger : MonoBehaviour
{
    [SerializeField] private Triggers triggerType;

    [Multiline] [SerializeField] private string message;
    private DialogueManager _dialogueManager;

    [SerializeField] private bool closeOnEnter;
    private void Start()
    {
        _dialogueManager = DialogueManager.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DoAction(true);
            if(closeOnEnter) 
                this.GetComponent<Collider>().enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DoAction(false);
            this.GetComponent<Collider>().enabled = false;
        }
    }

    private void DoAction(bool toShow)
    {
        switch(triggerType)
        {
            case Triggers.Dialogue:
                _dialogueManager.ShowDialogue(message,toShow);
                break;
            case Triggers.Gate:
                
                break;
            case Triggers.Naration:
                break;
            default:
                Debug.Log("Invalid Trigger");
                break;
        }
    }
}
