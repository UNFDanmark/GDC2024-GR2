using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    private InventoryManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindWithTag("God").GetComponent<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
