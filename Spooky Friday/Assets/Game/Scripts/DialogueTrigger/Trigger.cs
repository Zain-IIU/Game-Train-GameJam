using System;
using System.Diagnostics;
using DG.Tweening;
using TMPro.SpriteAssetUtilities;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;
using Debug = UnityEngine.Debug;

public  class Trigger : MonoBehaviour
{
    [SerializeField] private Triggers triggerType;

    [Multiline] [SerializeField] private string message;
    private DialogueManager _dialogueManager;

    [SerializeField] private Transform connectedGate;
    [SerializeField] private Transform button;
    [SerializeField] private bool closeOnEnter;
    [SerializeField] private bool closeOnExit;

    [SerializeField] private Vector2 minMaxButton;
    [SerializeField] private Vector2 minMaxDoor;
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
            if(closeOnExit)
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
                GateAction(toShow);
                break;
            case Triggers.Naration:
                break;
            default:
                Debug.Log("Invalid Trigger");
                break;
        }
    }

    private void GateAction(bool toOpen)
    {
        connectedGate.DOLocalMoveY(toOpen ? minMaxDoor.x : minMaxDoor.y, 1);
        button.DOLocalMoveY(toOpen ? minMaxButton.x : minMaxButton.y, 0.5f);
    }
}
