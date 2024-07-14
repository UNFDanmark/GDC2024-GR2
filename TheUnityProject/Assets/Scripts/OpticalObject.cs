using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class OpticalObject : MonoBehaviour
{
    private PlayerScript player;

    private MeshRenderer rend;

    private Mesh mesh;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
        rend = GetComponent<MeshRenderer>();
        mesh = GetComponent<Mesh>();
        GetComponent<Rigidbody>().velocity = new Vector3(0.2f, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        bool inFov = player.InFOV(transform.position);
        if (rend.enabled != inFov && inFov == false)
        {
            GameObject obj = Instantiate(gameObject);
            Destroy(obj.GetComponent<OpticalObject>());
            Destroy(obj.GetComponent<Rigidbody>());
            Destroy(obj.GetComponent<Collider>());
            obj.AddComponent<MemoryShadow>().Init(player);
        }

        rend.enabled = inFov;

    }
}
