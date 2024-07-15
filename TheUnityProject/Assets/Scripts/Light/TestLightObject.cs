using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLightObject : LightObject
{
    
    public override void LightInit()
    {
        
    }

    public override void LightUpdate()
    {
        if (InLight())
        {
            gameObject.transform.Rotate(new Vector3(0,10,0));
        }
    }
    
    public override void EntersLight()
    {
        
    }
    
    public override void EntersDark()
    {
        
    }
}
