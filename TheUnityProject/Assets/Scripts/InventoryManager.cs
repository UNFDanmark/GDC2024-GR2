using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public enum InventoryItemType
{
    BodyPart,
    Misc,
}

public class InventoryManager : MonoBehaviour
{
    public List<InventoryItemType> itemTypes;
    public List<string> itemNames;
    private DialogueManager dialogue;
    private List<bool> own = new List<bool>();
    
    public TMP_Text bodypartCounter;
    private int total;

    public int totalInGame(InventoryItemType itemType)
    {
        int total = 0;
        for (int i = 0; i < own.Count; i++)
        {
            if (itemTypes[i] == itemType)
            {
                total += 1;
            }
        }

        return total;
    }
    
    public int totalInInventory(InventoryItemType itemType)
    {
        int got = 0;
        for (int i = 0; i < own.Count; i++)
        {
            if (itemTypes[i] == itemType && own[i])
            {
                got += 1;
            }
        }

        return got;
    }
    
    public bool HasItem(int id)
    {
        return own[id];
    }

    public void GetItem(int id)
    {
        if (own[id])
        {
            throw new Exception("Already picked that up :/");
        }
        own[id] = true;
        Message mes = new Message();
        mes.text = "Picked up " + itemNames[id];
        mes.name = "";
        Dialogue dia = new Dialogue();
        dia.dialogue = new Message[] {mes};
        dialogue.DoDialogue(dia);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        dialogue = GetComponent<DialogueManager>();
        if(itemTypes.Count != itemNames.Count)
        {
            throw new Exception("Malformed item list :/");
        }
        foreach(InventoryItemType item in itemTypes)
        {
            own.Add(false);
        }
        
        total = totalInGame(InventoryItemType.BodyPart);
    }

    // Update is called once per frame
    void Update()
    {
        int got = totalInInventory(InventoryItemType.BodyPart);

        bodypartCounter.text = $"{got}/{total}";
    }
}
