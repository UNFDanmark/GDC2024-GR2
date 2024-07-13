using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryShadow : MonoBehaviour
{
    private PlayerScript player;
    
    public void Init(PlayerScript player)
    {
        this.player = player;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale /= 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.InFOV(transform.position))
        {
            Destroy(gameObject);
        }
    }
}
