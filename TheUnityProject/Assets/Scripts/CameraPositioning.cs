using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraPositioning : MonoBehaviour
{
    public float InitTilt;
    public float InitRadius;
    public float InitRotation;
    public float RadiusMin;
    public float RadiusMax;
    public float TiltMin;
    public float TiltMax;
    public Transform playerTf;
    
    public void Adjust(float Radius, float Tilt, float Rotation)
    {
        if (Radius < RadiusMin || Radius > RadiusMax)
        {
            return;
        }

        if (Tilt < TiltMin || Tilt > TiltMax)
        {
            return;
        }
        const float RadConv = Mathf.PI / 180.0f;
        Tilt *= RadConv;
        Rotation *= RadConv;
        float w = Mathf.Sin(Tilt);
        transform.position = playerTf.position + new Vector3(Mathf.Cos(Rotation) * w, Mathf.Cos(Tilt), Mathf.Sin(Rotation) * w) * Radius;
        transform.LookAt(playerTf);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        playerTf = GameObject.FindWithTag("Player").GetComponent<Transform>();
        Adjust(InitRadius, InitTilt, InitRotation);
    }

    // Update is called once per frame
    void Update()
    {
        Adjust(InitRadius, InitTilt, InitRotation);
    }
}
