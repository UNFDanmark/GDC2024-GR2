using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visibility : MonoBehaviour
{
    private Color startColor;
    private Renderer rend;
    private List<float> alphaEffects = new List<float>();
    private List<float> dimEffects = new List<float>();
    
    
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        float alphaEffect = 1;
        foreach (float effect in alphaEffects)
        {
            alphaEffect *= 1 - effect;
        } 
        float dimEffect = 1;
        foreach (float effect in dimEffects)
        {
            dimEffect *= 1 - effect;
        }

        Color newColor = startColor * dimEffect;
        newColor.a *= alphaEffect;
        rend.material.color = newColor;
    }

    public int AddAlphaEffect()
    {
        alphaEffects.Add(0);
        return alphaEffects.Count - 1;
    }
    public int AddDimEffect()
    {
        dimEffects.Add(0);
        return dimEffects.Count - 1;
    }

    public void ModifyAlphaEffect(int id, float effect)
    {
        if (effect > 1)
        {
            effect = 1;
        }else if (effect < 0)
        {
            effect = 0;
        }
        alphaEffects[id] = effect;
    }
    
    public void ModifyDimEffect(int id, float effect)
    {
        if (effect > 1)
        {
            effect = 1;
        }else if (effect < 0)
        {
            effect = 0;
        }
        dimEffects[id] = effect;
    }
}
