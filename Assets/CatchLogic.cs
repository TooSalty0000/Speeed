using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Ball").Length == 0)
        {
            LevelSpawner.instance.nextScene();
        }
    }
}
