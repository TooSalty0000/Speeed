using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class PullLogic : MonoBehaviour
{
    private GameObject[] pulls;
    // Start is called before the first frame update
    void Start()
    {
        pulls = GameObject.FindGameObjectsWithTag("Pull");
    }

    // Update is called once per frame
    void Update()
    {
        if (pulls.All(x => x.GetComponent<Pull>().pulled))
        {
            LevelSpawner.instance.nextScene();
        }
    }
}
