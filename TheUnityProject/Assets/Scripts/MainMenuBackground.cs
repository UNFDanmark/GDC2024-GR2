using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuBackground : MonoBehaviour
{
    public List<Texture> background;
    public float changeTimes;

    private float timeToNextChange;
    private int next;
    
    private RawImage image;
        // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<RawImage>();
        print(image);
        timeToNextChange = changeTimes;
        image.texture = background[0];
        next = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timeToNextChange -= Time.deltaTime;
        if (timeToNextChange <= 0)
        {
            timeToNextChange = changeTimes;
            
            image.texture = background[next];
            next++;
            if (next == background.Count)
            {
                next = 0;
            }

            
        }
    }
}
