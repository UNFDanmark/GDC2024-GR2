using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using Input = UnityEngine.Windows.Input;

public class DemonScript : LightObject
{
    public Vector3 startPosition;
    public List<Vector3> route;
    public List<float> speed;
    public bool repeat;
    private Renderer rend;
    private int current;
    
    private GameObject player;

    private bool demonMode;
    
    
    // Start is called before the first frame update
    public override void LightInit()
    {
        player = GameObject.FindWithTag("Player");
        demonMode = !InLight();
        
        current = 0;
        transform.position = startPosition;
        print(transform.position);
        rend = GetComponent<Renderer>();
        if (rend == null)
        {
            rend = GetComponentInChildren<Renderer>();
        }
        rend.enabled = demonMode;  
        print("NULL MESSAGE");
        print(rend == null);
    }

    // Update is called once per frame
    public override void LightUpdate()
    {
        if (demonMode)
        {
            if (current == route.Count)
            {
                if (repeat)
                {
                    current = 0;
                }
                else
                {
                    return;
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, route[current], speed[current] * Time.deltaTime);
            if (transform.position == route[current])
            {
                current++;

            }
        }
    }

    public override void EntersDark()
    {
        demonMode = true;
        rend.enabled = true;
    }

    public override void EntersLight()
    {
        demonMode = false;
        rend.enabled = false;
        // æændre tilbage
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (demonMode)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}