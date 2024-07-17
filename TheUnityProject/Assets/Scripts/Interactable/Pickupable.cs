using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : Interactable
{
    private InventoryManager inventory;
    private DialogueManager dialogue;

    public int itemId;

    
    public override void InteractableInit()
    {
        GameObject god = GameObject.FindWithTag("God");
        inventory = god.GetComponent<InventoryManager>();
        dialogue = god.GetComponent<DialogueManager>();

    }

    public override void OnInteract()
    {
        
        inventory.GetItem(itemId);
        Destroy(gameObject);
    }
    
}
