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
    public float betweenLettersTime;
    private TextAsset json;
    private Dialogue dialogue;
    private GameObject box;
    private GameObject nameBox;
    private PlayerScript player;
    private TMP_Text text;
    private TMP_Text name;
    private bool active = false;
    private int dialogueProgress;
    private int nextLetter;
    private float nextLetterIn;
    public override void InteractableInit()
    {
        json = Resources.Load(pathJson) as TextAsset;
        dialogue = JsonUtility.FromJson<Dialogue>(json.text);
        box = GameObject.FindWithTag("DialogueObj");
        text = GameObject.FindWithTag("Dialogue").GetComponent<TMP_Text>();
        name = GameObject.FindWithTag("DialogueName").GetComponent<TMP_Text>();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
        nameBox = GameObject.FindWithTag("DialogueNameObj");
        box.SetActive(false);
    }

    void setName()
    {
        string nameText = dialogue.dialogue[dialogueProgress].name;
        if (nameText == "")
        {
            nameBox.SetActive(false);
        }
        else
        {
            nameBox.SetActive(true);
            name.text = nameText;
        }
    }

    public override void InteractableUpdate()
    {
        if (active)
        {
            if (player.isSpace())
            {
                if (nextLetter == dialogue.dialogue[dialogueProgress].text.Length)
                {
                    dialogueProgress += 1;
                    if (dialogueProgress == dialogue.dialogue.Length)
                    {
                        active = false;
                        box.SetActive(false);
                        player.turnOnMovement();
                        return;
                    }
                    setName();
                    text.text = "";
                    nextLetter = 0;
                }
                else
                {
                    text.text = dialogue.dialogue[dialogueProgress].text;
                    nextLetter = dialogue.dialogue[dialogueProgress].text.Length;
                }
            }
            if (nextLetter != dialogue.dialogue[dialogueProgress].text.Length)
            {
                nextLetterIn -= Time.deltaTime;
                if (nextLetterIn <= 0)
                {
                    nextLetterIn = betweenLettersTime;
                    text.text += dialogue.dialogue[dialogueProgress].text[nextLetter];
                    nextLetter++;
                }
            }
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
        if (active)
        {
            return;
        }
        player.turnOffMovement();
        active = true;
        text.text = "";
        nextLetter = 0;
        nextLetterIn = betweenLettersTime;
        dialogueProgress = 0;
        setName();
        box.SetActive(true);
    }
}
