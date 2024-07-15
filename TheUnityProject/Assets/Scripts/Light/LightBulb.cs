using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBulb : MonoBehaviour
{
    private Light light;
    public float lightEffectRadius;
    
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isCloseEnough(Vector3 position)
    {
        return light.enabled && (transform.position - position).magnitude <= lightEffectRadius;
    }

    public void Toggle()
    {
        light.enabled = !light.enabled;
    }
}
