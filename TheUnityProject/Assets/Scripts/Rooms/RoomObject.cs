using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomObject : MonoBehaviour
{
    private Visibility vis;
    private int alphaEffect;


    private void Start()
    {
        if (GetComponent<Light>() != null)
        {
            return;
        }
        vis = GetComponent<Visibility>();
        alphaEffect = vis.AddAlphaEffect();
    }

    public void SetGone(float gone)
    {
        if (GetComponent<Light>() != null)
        {
            return;
        }
        if (gone == 1)
        {
            gameObject.SetActive(false);
        }
        vis.ModifyAlphaEffect(alphaEffect, gone);
    }

}
