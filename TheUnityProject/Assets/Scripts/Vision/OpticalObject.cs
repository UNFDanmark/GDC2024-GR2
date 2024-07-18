using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class OpticalObject : MonoBehaviour
{
    private PlayerScript player;

    private Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
        rend = GetComponent<Renderer>();
        if (rend == null)
        {
            rend = GetComponentInChildren<Renderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool inFov = player.InFOV(gameObject);
        if (rend.enabled != inFov && inFov == false)
        {
            GameObject obj = Instantiate(gameObject, transform.parent);
            Destroy(obj.GetComponent<OpticalObject>());
            Destroy(obj.GetComponent<Rigidbody>());
            Destroy(obj.GetComponent<Collider>());
            Destroy(obj.GetComponent<RegularLightObject>());
            Destroy(obj.GetComponent<Observe>());
            Destroy(obj.GetComponent<LightBulb>());
            Destroy(obj.GetComponent<LightObject>());
            Destroy(obj.GetComponent<DemonScript>());
            obj.AddComponent<MemoryShadow>();
        }

        rend.enabled = inFov;

    }
}
