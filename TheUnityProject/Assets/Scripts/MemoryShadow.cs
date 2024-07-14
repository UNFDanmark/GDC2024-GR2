using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryShadow : MonoBehaviour
{
    private PlayerScript player;
    private bool fading;
    private Vector3 sizeDecreaseRate;
    
    public void Init(PlayerScript player)
    {
        this.player = player;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        fading = false;
        transform.localScale /= 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (fading)
        {
            transform.localScale -= sizeDecreaseRate * Time.deltaTime;
            if (transform.localScale.x <= 0)
            {
                Destroy(gameObject);
            }

            
            
        }else if (player.InFOV(transform.position))
        {
            sizeDecreaseRate = transform.localScale;
            fading = true;
        }
    }
}
