using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : Interactable
{
    public List<LightBulb> lights;
    public bool lightSwitchState;
    
    public override void InteractableInit()
    {
        
    }

    public override void OnInteract()
    {
        lightSwitchState = !lightSwitchState;

        foreach (LightBulb bulb in lights)
        {
            bulb.Toggle();
        }
    }
}
