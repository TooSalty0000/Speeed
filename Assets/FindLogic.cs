using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindLogic : MonoBehaviour
{
    private _Toggle toggle;
    // Start is called before the first frame update
    void Start()
    {
        toggle = FindObjectOfType<_Toggle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (toggle.toggled) {
            LevelSpawner.instance.nextScene();
        }
    }
}
