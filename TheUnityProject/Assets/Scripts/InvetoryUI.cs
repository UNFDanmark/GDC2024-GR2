using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InvetoryUI : MonoBehaviour
{
    private InventoryManager manager;
    private TMP_Text bodypartCounter;
    
    private int total;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindWithTag("God").GetComponent<InventoryManager>();
        bodypartCounter = GetComponent<TMP_Text>();
        total = manager.totalInGame(InventoryItemType.BodyPart);
    }

    // Update is called once per frame
    void Update()
    {
        int got = manager.totalInInventory(InventoryItemType.BodyPart);

        bodypartCounter.text = $"Kropsdele:\n{got}/{total}";

    }
}
