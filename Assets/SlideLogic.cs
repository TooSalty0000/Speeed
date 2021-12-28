using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideLogic : MonoBehaviour
{
    private GameObject[] slides;
    // Start is called before the first frame update
    void Start()
    {
        slides = GameObject.FindGameObjectsWithTag("Slide");
    }

    // Update is called once per frame
    void Update()
    {
        bool allDone = true;
        foreach (var slide in slides)
        {
            if (!slide.GetComponent<Slide>().slided) {
                allDone = false;
                break;
            }
        }
        if (allDone) {
            LevelSpawner.instance.nextScene();
        }
    }
}
