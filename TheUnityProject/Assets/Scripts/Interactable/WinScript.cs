using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : Interactable
{
    private InventoryManager inv;
    private DialogueManager dia;
    
    public override void InteractableInit()
    {
        dia = GameObject.FindWithTag("God").GetComponent<DialogueManager>();
        inv = GameObject.FindWithTag("God").GetComponent<InventoryManager>();
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
        if (inv.totalInInventory(InventoryItemType.BodyPart) != 3)
        {
            Dialogue actual = new Dialogue();
            actual.dialogue = new Message[] { new Message() };
            actual.dialogue[0].text = "Gotta find out what happened to my wife... (Collect all 3 belongings/clues)";
            actual.dialogue[0].name = "";
            dia.DoDialogue(actual);
            return;
        }
        SceneManager.LoadScene("WinScene");
    }
}
