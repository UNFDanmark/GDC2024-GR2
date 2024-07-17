using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularLightObject : LightObject
{
    public Mesh DarkMesh;
    public Mesh LightMesh;
    public Material DarkMaterial;
    public Material LightMaterial;
    private Renderer ren;
    private MeshFilter meshFilter;
    
    public override void EntersLight()
    {

    }
    
    public override void EntersDark()
    {
        meshFilter.mesh = DarkMesh;
        ren.materials[0] = DarkMaterial;
    }
    
    public override void LightInit()
    {
        meshFilter = gameObject.GetComponent<MeshFilter>();
        ren = gameObject.GetComponent<MeshRenderer>();
    }
}
