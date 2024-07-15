using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

[Serializable]
public class Dialogue
{
    public string name;
    public string text;
}

public class Observe : Interactable
{
    public string pathJson;
    private Dialogue[] dialogue;
    private GameObject box;
    private TMP_Text text;
    public override void InteractableInit()
    {
        string path = Application.persistentDataPath + pathJson;
        StreamReader reader = new StreamReader(path);
        string json = reader.ReadToEnd();
        dialogue = JsonUtility.FromJson<Dialogue[]>(json);
        box = GameObject.FindWithTag("Dialogue");
        text = transform[0].gameObject
    }

    public override void InteractableUpdate()
    {
        
    }

    public override void InteractableStart()
    {
        
    }

    public override void InteractableEnd()
    {
        
    }

    public override void OnInteract()
    {
        
        
    }
}
