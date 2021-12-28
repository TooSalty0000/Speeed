using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLogic : MonoBehaviour
{
    private GameObject[] Moves;
    // Start is called before the first frame update
    void Start()
    {
        Moves = GameObject.FindGameObjectsWithTag("Movable");
    }

    // Update is called once per frame
    void Update()
    {
        bool allDone = true;
        foreach (var move in Moves)
        {
            if (!move.GetComponent<Move>().moved)
            {
                allDone = false;
                break;
            }
        }
        if (allDone)
        {
            LevelSpawner.instance.nextScene();
        }
    }
}
