using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]
public class DialogueScriptable : ScriptableObject
{
    public Dialogue[] dialogues;
    public Actor[] actors;

    public bool choices;
    public Response[] responses;
}

[System.Serializable]
public class Dialogue
{
    public int actorId;
    [TextArea] public string text;
}

[System.Serializable]
public class Actor
{
    public string name;
}

[System.Serializable]
public class Response
{
    public GameObject responsesPrefab;
    public DialogueScriptable nextConversation;
}
