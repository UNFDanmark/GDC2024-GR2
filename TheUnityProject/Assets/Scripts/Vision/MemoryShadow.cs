using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MemoryShadow : MonoBehaviour
{
    private SketchSettings globalSettings;
    private float greyout = 0;
    private float dissapear = 0;
    private PlayerScript player;
    private bool fading;
    private Visibility vis;

    private int alphaEffect;

    private int dimEffect;
    // Start is called before the first frame update
    void Start()
    {
        vis = GetComponent<Visibility>();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
        fading = false;
        globalSettings = GameObject.FindWithTag("God").GetComponent<SketchSettings>();
        alphaEffect = vis.AddAlphaEffect();
        dimEffect = vis.AddDimEffect();
    }

    // Update is called once per frame
    void Update()
    {
        if (greyout != 1)
        {
            greyout += Time.deltaTime / globalSettings.memoryGreyoutTime;
            if (greyout >= 1)
            {
                greyout = 1;
            }
            vis.ModifyAlphaEffect(alphaEffect, greyout * globalSettings.memoryGreyoutAmount);
        }
        if (fading)
        {
            if (dissapear >= 1)
            {
                Destroy(gameObject);
            }

            dissapear += Time.deltaTime / globalSettings.memoryDissapearTime;
            vis.ModifyDimEffect(dimEffect, dissapear);
        }
        else if (player.InFOV(gameObject))
        {
            fading = true;
        }
        
        
        
    }
}
