using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : Interactable
{
    public List<LightBulb> lights;
    public bool lightSwitchState;
    private AudioSource audio;
    public override void InteractableInit()
    {
        audio = GetComponent<AudioSource>();
    }

    public override void OnInteract()
    {
        audio.PlayOneShot(audio.clip);
        lightSwitchState = !lightSwitchState;

        foreach (LightBulb bulb in lights)
        {
            bulb.Toggle();
        }
    }
}
