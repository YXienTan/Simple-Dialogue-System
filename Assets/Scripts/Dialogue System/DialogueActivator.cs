using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueActivator : MonoBehaviour
{
    public DialogueTrigger trigger;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("NPC"))
        {
            trigger = other.GetComponent<DialogueTrigger>();
            trigger.StartDialogue();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            trigger = null;
            DialogueManager.Instance.StopDialogue();
        }
    }
}
