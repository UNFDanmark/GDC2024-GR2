using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeadacheScript : LightObject
{
    [SerializeField] private float headache = 0;
    public Slider headacheBar;
    
    public float headacheRate;

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
    }

}
