using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text dialogueText;
    public TMP_Text nameText;
    public Image dialogueBox;
    public Button nextButton;
    public Transform responseBox;

    Dialogue[] currentDialogues;
    Actor[] currentActors;
    bool currentChoices;
    Response[] currentResponse;
    int activeDialogue = 0;

    private static DialogueManager _instance;
    public static DialogueManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("DialogueManager is null");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        dialogueBox.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);
    }

    public void OpenDialogue(DialogueScriptable dialogueScriptable)
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        currentDialogues = dialogueScriptable.dialogues;
        currentActors = dialogueScriptable.actors;
        currentChoices = dialogueScriptable.choices;
        currentResponse = dialogueScriptable.responses;
        activeDialogue = 0;

        dialogueBox.gameObject.SetActive(true);
        if(dialogueScriptable.dialogues.Length > 0)
        {
            nextButton.gameObject.SetActive(true);
        }

        foreach (Transform child in responseBox)
        {
            Destroy(child.gameObject);
        }

        Debug.Log("Start Conversation! Loaded dialogues: " + dialogueScriptable.dialogues.Length);
        DisplayDialogue();
    }

    public void DisplayDialogue()
    {
        Dialogue dialogueToDisplay = currentDialogues[activeDialogue];
        dialogueText.text = dialogueToDisplay.text;

        Actor actorToDisplay = currentActors[dialogueToDisplay.actorId];
        nameText.text = actorToDisplay.name;
    }

    public void NextDialogue()
    {
        activeDialogue++;
        if (activeDialogue < currentDialogues.Length)
        {
            DisplayDialogue();
        }
        else if (activeDialogue == currentDialogues.Length)
        {
            if (currentChoices)
            {
                nextButton.gameObject.SetActive(false);
                foreach (Response responses in currentResponse)
                {
                    Instantiate(responses.responsesPrefab, responseBox);
                }
            }
            else
            {
                StopDialogue();
            }
        }
    }

    public void StopDialogue()
    {
        Debug.Log("Conversation ended!");
        dialogueBox.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        foreach (Transform child in responseBox)
        {
            Destroy(child.gameObject);
        }

        currentDialogues = null;
        currentActors = null;
        currentChoices = false;
        activeDialogue = 0;
    }

    public void Response(int id)
    {
        OpenDialogue(currentResponse[id].nextConversation);
        Debug.Log("Response!");
    }
}
