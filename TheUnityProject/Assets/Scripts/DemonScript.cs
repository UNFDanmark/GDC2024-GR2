using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DemonScript : LightObject
{
    public float patience;
    
    private NavMeshAgent agent;
    private GameObject player;

    private bool demonMode;
    
    
    
    // public variables til mesh og materials
    public Renderer ren;
    public Material[] mat;
    
    
    
    // Start is called before the first frame update
    public override void LightInit()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        demonMode = InLight();
    }

    // Update is called once per frame
    public override void LightUpdate()
    {
        if (demonMode)
        {
            patience -= Time.deltaTime;
            if (patience <= 0)
            {
                agent.destination = player.transform.position;
            }
        }
    }

    public override void EntersDark()
    {
        demonMode = true;
        
        ren = GameObject.G
        
        // ændre mesh og materials
    }

    public override void EntersLight()
    {
        demonMode = false;
        
        // æændre tilbage
    }

    private void OnCollisionEnter(Collision other)
    {
        // check other.playertag... 
        // demonmode enabled (if)
        // game over screen
    }
}