using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public float triggerBoxRadius = 1;
    public float interactCooldown = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameObject child = Instantiate(new GameObject("Interact trigger"), new Vector3(0, 0, 0), Quaternion.identity);
        child.transform.SetParent(transform, false);
        child.AddComponent<InteractChild>();
        BoxCollider col = child.AddComponent<BoxCollider>();
        col.size = new Vector3(triggerBoxRadius, 10, triggerBoxRadius);
        col.isTrigger = true;
        
    }

    // Update is called once per frame
    void Update()
    {

    }



    public virtual void InteractableInit()
    {
        
    }

    public virtual void InteractableUpdate()
    {
        
    }

    public virtual void InteractableStart()
    {
        
    }

    public virtual void InteractableEnd()
    {
        
    }

    public virtual void OnInteract()
    {
        
    }
}
