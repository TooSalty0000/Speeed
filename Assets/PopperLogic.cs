using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopperLogic : MonoBehaviour
{
    private GameObject[] poppers;
    private void Start() {
        // get all gameobjects with tag Popper and store it in a list
        poppers = GameObject.FindGameObjectsWithTag("Popper");
    }

    private void Update() {
        //if all poppers are null in the list, set switchReady to true
        bool allGone = true;
        foreach (var p in poppers)
        {
            if (p) {
                allGone = false;
                break;
            }
        }
        if (allGone) {
            LevelSpawner.instance.nextScene();
        }
        
    }
}
