using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomScript : MonoBehaviour
{
    private bool inside = false;
    private MeshRenderer[] children;
    
    // Start is called before the first frame update
    void Start()
    {
        children = gameObject.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer child in children)
        {
            print(child);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (MeshRenderer child in children)
            {
                child.enabled = true;
            }
            inside = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (MeshRenderer child in children)
            {
                child.enabled = false;
            }
            inside = false;
        }
    }
}
