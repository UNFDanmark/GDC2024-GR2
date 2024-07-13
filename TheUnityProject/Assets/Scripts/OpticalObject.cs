using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpticalObject : MonoBehaviour
{
    public float fov;
    
    private GameObject player;

    private MeshRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 fromPlayer = transform.position - player.transform.position;
        float angle = Mathf.Abs(Vector3.Angle(fromPlayer, player.transform.forward));
        renderer.enabled = angle <= fov;
    }
}
