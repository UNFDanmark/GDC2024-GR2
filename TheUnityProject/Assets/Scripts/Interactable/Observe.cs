using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using TMPro;
using UnityEditor;
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
    public string pathJsonNoItem;
    public int noItem;
    public int item;
    private TextAsset json;
    private Dialogue dialogue;
    private Dialogue noItemDialogue;
    private DialogueManager manager;
    public InventoryManager inv;
    private bool active = false;
    public List<LightBulb> turnOffWhenDone;
    public AudioClip bigMferClip;
    
    public override void InteractableInit()
    {
        json = Resources.Load(pathJson) as TextAsset;
        inv = GameObject.FindWithTag("God").GetComponent<InventoryManager>();
        dialogue = JsonUtility.FromJson<Dialogue>(json.text);
        manager = GameObject.FindWithTag("God").GetComponent<DialogueManager>();
        if (pathJsonNoItem != "")
        {
            noItemDialogue = JsonUtility.FromJson<Dialogue>((Resources.Load(pathJsonNoItem) as TextAsset).text);
        }
        else
        {
            noItemDialogue = null;
        }
    }

    public override void InteractableUpdate()
    {
        if (active && !manager.Active())
        {
            active = false;
            Dialogue dia = new Dialogue();
            dia.dialogue = new Message[] { new Message() };
            dia.dialogue[0].name = "You";
            dia.dialogue[0].text = "Ah shit";
            foreach (LightBulb light in turnOffWhenDone)
            {
                light.Toggle();
            }
            GetComponent<AudioSource>().Play(); 
            GameObject.FindWithTag("Music").GetComponent<AudioSource>().Stop();
            GameObject.FindWithTag("Music").GetComponent<AudioSource>().clip = bigMferClip;
            GameObject.FindWithTag("Music").GetComponent<AudioSource>().volume = 1f;
            GameObject.FindWithTag("Music").GetComponent<AudioSource>().Play();
            manager.DoDialogue(dia);
    }
    }

    public override void InteractableStart()
    {
        
    }

    public override void InteractableEnd()
    {
        
    }

    public override void OnInteract()
    {
        if (inv.HasItem(noItem))
        {
            active = true;
            manager.DoDialogue(dialogue);
            inv.GetItem(item);
        }
        else
        {
            manager.DoDialogue(noItemDialogue);
        }
    }
    
    
}
