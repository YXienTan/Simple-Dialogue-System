using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueScriptable conversation;
    [SerializeField] private DialogueManager manager;

    public void StartDialogue()
    {
        manager.OpenDialogue(conversation);
    }
}
