using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class OpticalObject : MonoBehaviour
{
    private PlayerScript player;

    private MeshRenderer renderer;

    private Mesh mesh;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
        renderer = GetComponent<MeshRenderer>();
        mesh = GetComponent<Mesh>();
        
    }

    // Update is called once per frame
    void Update()
    {
        bool inFov = player.InFOV(transform.position);
        if (renderer.enabled != inFov && inFov == false)
        {
            GameObject obj = Instantiate(gameObject);
            Destroy(obj.GetComponent<OpticalObject>());
            obj.AddComponent<MemoryShadow>().Init(player);
        }

        renderer.enabled = inFov;

    }
}
