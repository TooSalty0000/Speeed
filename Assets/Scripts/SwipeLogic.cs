using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SwipeLogic : MonoBehaviour
{
    private GameObject[] swipes;
    // Start is called before the first frame update
    void Start()
    {
        swipes = GameObject.FindGameObjectsWithTag("Swipe");
    }

    // Update is called once per frame
    void Update()
    {
        if (swipes.All(x => x.GetComponent<Swipe>().swiped))
        {
            LevelSpawner.instance.nextScene();
        }
    }
}
