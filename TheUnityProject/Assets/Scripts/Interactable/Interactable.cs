using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public float interactBoxRadius = 1;
    public float interactCooldown = 0;
    private Renderer rend;
    private InteractChild child;
    
    public float glow;
    public float glowTime;
    public Color glowTint;

    private float actuelGlow;
    private bool glowing;

    // Start is called before the first frame update
    void Start()
    {
        GameObject child = new GameObject("Interact trigger");
        child.transform.SetParent(transform, false);
        print(child.transform.parent);
        child.AddComponent<InteractChild>();
        BoxCollider col = child.AddComponent<BoxCollider>();
        col.size = new Vector3(interactBoxRadius, 10, interactBoxRadius);
        col.isTrigger = true;
        rend = GetComponent<Renderer>();
        this.child = child.GetComponent<InteractChild>();
    }
    public bool IsInside()
    {
        return child.isInside;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsInside())
        {
            actuelGlow += Time.deltaTime / glowTime;
            if (actuelGlow > 1)
            {
                actuelGlow = 1;
            }
        }
        else
        {
            actuelGlow -= Time.deltaTime / glowTime;
            if (actuelGlow < 0)
            {
                actuelGlow = 0;
            }   
        }
        rend.material.SetColor("_EmissionColor", glowTint * actuelGlow * glow);
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
