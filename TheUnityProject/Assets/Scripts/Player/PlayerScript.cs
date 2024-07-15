using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody rb;
    public float walkingAcc;
    public float rotationSpeed;
    public float fov;
    public float visionAroundRadius;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public bool InFOV(Vector3 position)
    {
        position.y = 0;
        Vector3 ownPosition = transform.position;
        ownPosition.y = 0;
        Vector3 fromPlayer = position - ownPosition;
        if (fromPlayer.magnitude <= visionAroundRadius)
        {
            return true;
        }

        float angle = Mathf.Abs(Vector3.Angle(fromPlayer, transform.forward));
        return angle <= fov;
    }

    // Update is called once per frame
    void Update()
    {
        float vert = Input.GetAxis("Vertical");
        float hori = Input.GetAxis("Horizontal");
        rb.AddForce(Time.deltaTime * walkingAcc * new Vector3(-vert, 0, hori), ForceMode.Impulse);
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
