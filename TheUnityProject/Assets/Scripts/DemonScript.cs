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
    public float patience;
    
    private NavMeshAgent agent;
    private GameObject player;

    private bool demonMode;
    
    
    // public variables til mesh og materials
    private Renderer ren;
    private MeshFilter meshFilter;
    public Mesh DarkMesh;
    public Mesh LightMesh;
    public Material DarkMaterial;
    public Material LightMaterial;
    private Collider col;
    
    // Start is called before the first frame update
    public override void LightInit()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        demonMode = InLight();
        meshFilter = gameObject.GetComponent<MeshFilter>();
        ren = gameObject.GetComponent<MeshRenderer>();
        col = gameObject.GetComponent<Collider>();
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
        meshFilter.mesh = DarkMesh;
        ren.materials[0] = DarkMaterial;
        col.isTrigger = true;
        // ændre mesh og materials
    }

    public override void EntersLight()
    {
        demonMode = false;
        meshFilter.mesh = LightMesh;
        ren.materials[0] = LightMaterial;
        col.isTrigger = false;
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