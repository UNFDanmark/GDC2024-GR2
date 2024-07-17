using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private GameObject box;
    private GameObject nameBox;
    private TMP_Text text;
    private TMP_Text name;
    private bool active;
    private Dialogue dialogue;
    private int dialogueProgress;
    private int nextLetter;
    private float nextLetterIn;
    private PlayerScript player;
    public float betweenLettersTime;
    public AudioSource dialogSound;
    
    // Start is called before the first frame update
    void Start()
    {
        box = GameObject.FindWithTag("DialogueObj"); 
        text = GameObject.FindWithTag("Dialogue").GetComponent<TMP_Text>();
        name = GameObject.FindWithTag("DialogueName").GetComponent<TMP_Text>();
        nameBox = GameObject.FindWithTag("DialogueNameObj");
        box.SetActive(false);
        active = false;
        player = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
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
                    if (!dialogSound.isPlaying)
                    {
                        dialogSound.PlayOneShot(dialogSound.clip);
                    }
                    nextLetterIn = betweenLettersTime;
                    text.text += dialogue.dialogue[dialogueProgress].text[nextLetter];
                    nextLetter++;
                }
            }
        }
    }

    public void DoDialogue(Dialogue dialogue)
    {
        if (active)
        {
            return;
        }
        player.turnOffMovement();
        this.dialogue = dialogue;
        text.text = "";
        nextLetter = 0;
        nextLetterIn = betweenLettersTime;
        dialogueProgress = 0;
        active = true;
        setName();
        box.SetActive(true);
        
        
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
}
