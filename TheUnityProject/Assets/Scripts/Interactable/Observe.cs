using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using Input = UnityEngine.Windows.Input;

[Serializable]
public class Message
{
    public string name;
    public string text;
}

public class Dialogue
{
    public Message[] dialogue;
}

public class Observe : Interactable
{
    public string pathJson;
    private TextAsset json;
    private Dialogue dialogue;
    private DialogueManager manager;

    public override void InteractableInit()
    {
        json = Resources.Load(pathJson) as TextAsset;
        dialogue = JsonUtility.FromJson<Dialogue>(json.text);
        manager = GameObject.FindWithTag("God").GetComponent<DialogueManager>();
    }

    public override void InteractableStart()
    {
        
    }

    public override void InteractableEnd()
    {
        
    }

    public override void OnInteract()
    {
        manager.DoDialogue(dialogue);
    }
    
    
}
