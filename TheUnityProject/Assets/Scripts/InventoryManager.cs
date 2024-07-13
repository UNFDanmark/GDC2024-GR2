using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    private List<bool> own = new List<bool>();

    public bool HasItem(int id)
    {
        return own[id];
    }

    public void GetItem(int id)
    {
        if (own[id])
        {
            print("Already picked that up");
            int a = 0;
            int b = 1 / a;
        }
        own[id] = true;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if(itemTypes.Count != itemNames.Count)
        {
            int a = 0;
            print("lol stupid");
            int b = 1 / a;
            while(true){}
        }
        foreach(InventoryItemType item in itemTypes)
        {
            own.Append(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
