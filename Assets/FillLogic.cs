using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

public class FillLogic : MonoBehaviour
{
    [SerializeField]
    private Fill fill;
    [SerializeField]
    private Collider2D[] testers;
    private bool[] checkers;
    // Start is called before the first frame update
    void Start()
    {
        checkers = new bool[testers.Length];
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < testers.Length; i++)
        {
            foreach (var particle in fill.particles)
            {
                if (testers[i].OverlapPoint(particle.transform.position) && particle.GetComponent<Particle>().touching)
                {
                    checkers[i] = true;
                }
            }
        }
        // if all of checkers is true, next scene
        if (checkers.All(x => x))
        {
            fill.enabled = false;
            LevelSpawner.instance.nextScene();
        } else {
            // set all checkers to false;
            for (int i = 0; i < checkers.Length; i++)
            {
                checkers[i] = false;
            }
        }
    }
}
