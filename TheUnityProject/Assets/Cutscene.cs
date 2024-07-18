using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cutscene : MonoBehaviour
{
    private RawImage img;

    public List<Texture> imgs;

    private int current = 1;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<RawImage>();
        img.texture = imgs[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (current == imgs.Count)
            {
                SceneManager.LoadScene("MainMenu");
                return;
            }
            img.texture = imgs[current++];
        }

        
    }
}
