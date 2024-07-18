using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomScript : MonoBehaviour
{
    private bool inside = false;
    private float gone;
    public float goneTime;

    private void Start()
    {

    }

    public bool Inside()
    {
        return inside;
    }
    
    private void Update()
    {
        if (inside && gone != 0)
        {
            gone -= Time.deltaTime / goneTime;
            if (gone <= 0)
            {
                gone = 0;
            }
            foreach (Transform t in transform)
            {
                t.gameObject.GetComponent<RoomObject>().SetGone(gone);
            }
        }
        else if (!inside && gone != 1)
        {
            gone += Time.deltaTime / goneTime;
            foreach (Transform t in transform)
            {
                t.gameObject.GetComponent<RoomObject>().SetGone(gone);
            }
            if (gone >= 1)
            {
                gone = 1;
                foreach (Transform child in transform)
                {
                    child.gameObject.SetActive(false);
                }
            }
            
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!inside)
            {
                inside = true;
                foreach (Transform child in transform)
                {
                    child.gameObject.SetActive(true);
                }
                
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (inside)
            {
                inside = false;
            }
        }
    }
}
