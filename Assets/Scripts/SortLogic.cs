using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortLogic : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Sorts;
    private void Update() {
        // if all positions of the sorts are 1 away from the previous sort's position in the array, then next scene
        bool allDone = true;
        for (int i = 1; i < Sorts.Length; i++)
        {
            if (Mathf.Abs((Sorts[i].transform.position.x - Sorts[i - 1].transform.position.x) - 1) > 0.1f) {
                allDone = false;
                break;
            }
        }
        if (allDone) {
            LevelSpawner.instance.nextScene();
        }    
    }
}
