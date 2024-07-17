using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : Interactable
{
    public override void InteractableInit()
    {
        
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
        SceneManager.LoadScene("WinScene");
    }
}
