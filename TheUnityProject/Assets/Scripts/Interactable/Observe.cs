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
    private PlayerScript player;
    private TMP_Text text;
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
        player = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
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
        player.turnOffMovement();
        active = true;
        text.text = "";
        nextLetter = 0;
        nextLetterIn = betweenLettersTime;
        dialogueProgress = 0;
        box.SetActive(true);
    }
}
