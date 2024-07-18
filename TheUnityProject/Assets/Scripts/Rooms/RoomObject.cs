using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomObject : MonoBehaviour
{
    private Visibility vis;
    private int alphaEffect;
    private Light light;
    public bool ifLightThenWhat;

    private void Start()
    {
        light = GetComponent<Light>();
        if (light != null)
        {
            light.enabled = ifLightThenWhat;
            return;
        }
        vis = GetComponent<Visibility>();
        alphaEffect = vis.AddAlphaEffect();
    }

    public void SetGone(float gone)
    {
        if (vis == null)
        {
            return;
        }
        if (light != null)
        {
            light.enabled = gone != 0;
            return;
        }
        if (gone == 1)
        {
            gameObject.SetActive(false);
        }
        vis.ModifyAlphaEffect(alphaEffect, gone);
    }

}
