using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeadacheScript : LightObject
{
    [SerializeField] private float headache = 0;
    public Slider headacheBar;
    public float headacheRate;
    public float recoveryRate;
    private AudioSource source;

    public override void LightInit()
    {
        source = GetComponent<AudioSource>();
    }
    public override void LightUpdate()
    {
        if (InLight())
        {
            headache += headacheRate * Time.deltaTime;
            headacheBar.value = headache;

            if (headache >= 1)
            { 
                SceneManager.LoadScene("GameOver");
            }
        }
        else
        {
            headache -= recoveryRate * Time.deltaTime;
            headacheBar.value = headache;

            if (headache <= 0)
            {
                headache = 0;
            }
            
        }
    }
}