using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MemoryShadow : MonoBehaviour
{
    private PlayerScript player;
    private bool fading;
    private Vector3 sizeDecreaseRate;

    private Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
        rend = GetComponent<MeshRenderer>();
        rend.material.SetColor("_Color", new Color(255/2, 255/2, 255/2, 255/2));
        fading = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (fading)
        {
            
            
        }else if (player.InFOV(transform.position))
        {
            fading = true;
        }
    }
}
