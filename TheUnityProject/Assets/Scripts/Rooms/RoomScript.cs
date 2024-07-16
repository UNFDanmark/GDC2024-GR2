using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomScript : MonoBehaviour
{
    private bool inside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
            inside = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            inside = false;
        }
    }
}
