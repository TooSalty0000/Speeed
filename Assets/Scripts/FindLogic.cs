using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FindLogic : MonoBehaviour
{
    private _Toggle[] toggles;
    // Start is called before the first frame update
    void Start()
    {
        toggles = FindObjectsOfType<_Toggle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (toggles.All(x => x.toggled)) {
            LevelSpawner.instance.nextScene();
        }
    }
}
