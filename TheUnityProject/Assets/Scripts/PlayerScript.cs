using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody rb;
    public float FullSpeedTime;
    public float FullSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    float AdjustAxis(float Previous, float Direction)
    {
        if(Direction == 0f && Mathf.Abs(Previous) < Time.deltaTime * FullSpeed / FullSpeedTime)
        {
            return 0f;
        }
        float New = Previous + Mathf.Sign(Direction * FullSpeed - Previous) * Time.deltaTime * FullSpeed / FullSpeedTime;
        if(New < -FullSpeed)
        {
            New = -FullSpeed;
        }else if(New > FullSpeed)
        {
            New = FullSpeed;
        }
        print(Mathf.Sign(Direction * FullSpeed - Previous));
        return New;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vel = rb.velocity;
        vel.x = AdjustAxis(vel.x, Input.GetAxisRaw("Vertical"));
        vel.z = AdjustAxis(vel.z, Input.GetAxisRaw("Horizontal"));
        rb.velocity = vel;
    }
}
