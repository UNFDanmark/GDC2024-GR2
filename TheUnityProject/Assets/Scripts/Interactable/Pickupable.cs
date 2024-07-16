using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : Interactable
{
    private InventoryManager manager;
    public int itemId;
    
    public override void InteractableInit()
    {
        manager = GameObject.FindWithTag("God").GetComponent<InventoryManager>();
    }

    public override void OnInteract()
    {
        manager.GetItem(itemId);
        Destroy(gameObject);
    }
}
