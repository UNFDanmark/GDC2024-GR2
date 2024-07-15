using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LightObject : MonoBehaviour
{
    private LightBulb[] lights;
    private bool state;
    
    GameObject FindRoom()
    {
        Transform t = transform;
        while (t.parent != null)
        {
            if (t.parent.CompareTag("Room"))
            {
                return t.parent.gameObject;
            }
            t = t.parent.transform;
        }

        throw new Exception("Not in room");
    }

    bool checkLight()
    {
        foreach (LightBulb light in lights)
        {
            if (light.isCloseEnough(transform.position))
            {
                return true;
            }
        }

        return false;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        lights = FindRoom().GetComponentsInChildren<LightBulb>();
        LightInit();
        LightChange();
    }

    // Update is called once per frame
    void Update()
    {
        bool newState = checkLight();
        if (state != newState)
        {
            state = newState;
            LightChange();
        }
        LightUpdate();
    }

    void LightChange()
    {
        if (state)
        {
            EntersLight();
        }
        else
        {
            EntersDark();
        }
    }

    public bool InLight()
    {
        return state;
    }

    public virtual void LightInit()
    {
        
    }

    public virtual void LightUpdate()
    {
        
    }
    
    public virtual void EntersLight()
    {
        
    }
    
    public virtual void EntersDark()
    {
        
    }
}
