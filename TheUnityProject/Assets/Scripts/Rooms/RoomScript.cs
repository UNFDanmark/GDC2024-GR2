using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomScript : MonoBehaviour
{
    private bool inside;
    private bool beenIn = false;
    public bool startIn;
    private float gone;
    public float goneTime;
    public string jsonDialogue;
    private TextAsset json;
    private DialogueManager manager;
    private Dialogue dialogue;
    public Collider closeOffExit;
    public RoomScript previousRoom;
    private void Start()
    {
        if (jsonDialogue == "")
        {
            json = null;
            dialogue = null;
        }
        else
        {
            json = Resources.Load(jsonDialogue) as TextAsset;
            dialogue = JsonUtility.FromJson<Dialogue>(json.text);
        }
        
        manager = GameObject.FindWithTag("God").GetComponent<DialogueManager>();
        inside = startIn;
        beenIn = startIn;
        if (!inside)
        {
            gone = 1;
            foreach (Transform t in transform)
            {
                t.gameObject.SetActive(false);
            }
        }
    }

    public bool Inside()
    {
        return inside;
    }
    
    private void Update()
    {
        if (startIn)
        {
            startIn = false;
            manager.DoDialogue(dialogue);
        }
        if (inside && !previousRoom.Inside())
        {
            beenIn = true;
            foreach (Transform t in previousRoom.gameObject.transform)
            {
                t.gameObject.SetActive(false);
            }
        }
        /*if (inside && gone != 0)
        {
            if (!previousRoom.Inside())
            {
                beenIn = true;
            }

            gone -= Time.deltaTime / goneTime;
            if (gone <= 0)
            {
                gone = 0;
            }

            if (gone > 0.5)
            {
                if (dialogue != null)
                {
                    manager.DoDialogue(dialogue);
                }
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
                
                Destroy(gameObject);
            }
            
        }*/

        
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
                if (closeOffExit != null)
                {
                    closeOffExit.enabled = true;
                }

                Destroy(gameObject);
            }
        }
    }
}
