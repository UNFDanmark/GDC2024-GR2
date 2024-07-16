using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public float timeToExpand;
    public float expansionFactor;

    private Vector3 originalSize;

    private float expansion;
    
    private bool expanding;
    // Start is called before the first frame update
    void Start()
    {
        originalSize = transform.localScale;
        expanding = false;
        expansion = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float change = Time.deltaTime / timeToExpand;
        if (expanding)
        {
            if (expansion >= 1 - change)
            {
                expansion = 1;
            }
            else
            {
                expansion += change;
            }
        }
        else
        {
            if (expansion <= change)
            {
                expansion = 0;
            }
            else
            {
                expansion -= change;
            }
        }
        print(expansion);
        transform.localScale = originalSize * (1 + (expansionFactor - 1) * expansion);
    }

    private void OnMouseEnter()
    {
        print("lol");
        expanding = true;
    }

    private void OnMouseExit()
    {
        expanding = false;
    }

    public void OnButtonClick()
    {
        SceneManager.LoadScene("MainScene");
    }
}
