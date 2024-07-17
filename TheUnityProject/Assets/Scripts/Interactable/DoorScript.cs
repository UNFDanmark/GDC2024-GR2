using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : Interactable
{
    public int itemNeeded;
    private InventoryManager manager;
    private  Collider col;
    public override void InteractableInit()
    {
        manager = GameObject.FindWithTag("God").GetComponent<InventoryManager>();
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
        if (manager.HasItem(itemNeeded))
        {
            col.enabled = !col.enabled;
        }
    }
}
