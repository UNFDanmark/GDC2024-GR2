using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody rb;
    private Transform bodyTf;
    public float fullSpeedTime;
    public float fullSpeed;
    public float rotationSpeed;
    public float fov;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    public bool InFOV(Vector3 position)
    {
        Vector3 fromPlayer = position - transform.position;
        float angle = Mathf.Abs(Vector3.Angle(fromPlayer, transform.forward));
        return angle <= fov;
    }

    float AdjustAxis(float previous, float direction)
    {
        if(direction == 0f && Mathf.Abs(previous) < Time.deltaTime * fullSpeed / fullSpeedTime)
        {
            return 0f;
        }
        float New = previous + Mathf.Sign(direction * fullSpeed - previous) * Time.deltaTime * fullSpeed / fullSpeedTime;
        if(New < -fullSpeed)
        {
            New = -fullSpeed;
        }else if(New > fullSpeed)
        {
            New = fullSpeed;
        }
        return New;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vel = rb.velocity;
        float vert = Input.GetAxis("Vertical");
        float hori = Input.GetAxis("Horizontal");
        vel.x = AdjustAxis(vel.x, -vert);
        vel.z = AdjustAxis(vel.z, hori);
        rb.velocity = vel;
        //vert hori
        //-1 -1 AS = 135 grader
        //0 -1 A = 180 grader
        //1 -1 AW = 225 grader
        //-1 0 S = 90 grader
        //0 0 Nothing
        //1 0 W = 270 grader
        //-1 1 SD = 45 grader
        //0 1 D = 0 grader
        //1 1 DW = 315 grader
        float degrees = -1;
        if (vert == -1 && hori == -1) degrees = 135;
        else if (vert == 0 && hori == -1) degrees = 180;
        else if (vert == 1 && hori == -1) degrees = 225;
        else if (vert == -1 && hori == 0) degrees = 90;
        else if (vert == 1 && hori == 0) degrees = 270;
        else if (vert == -1 && hori == 1) degrees = 45;
        else if (vert == 0 && hori == 1) degrees = 0;
        else if (vert == 1 && hori == 1) degrees = 315;
        if (degrees != -1)
        {
            float from = transform.eulerAngles.y;
            float rotation = rotationSpeed * Time.deltaTime;
            float diff = Mathf.DeltaAngle(from, degrees);
            if (Mathf.Abs(diff) < rotation)
            {
                transform.rotation = Quaternion.Euler(0, degrees, 0);
            }
            else
            {
                if (diff < 0)
                {
                    rotation = -rotation;
                }

                transform.RotateAround(transform.position, Vector3.up, rotation);
            }
        }
        
    }
}
