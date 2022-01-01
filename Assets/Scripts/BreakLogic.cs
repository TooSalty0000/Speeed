using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakLogic : MonoBehaviour
{
    private Break breakScript;
    // Start is called before the first frame update
    void Start()
    {
        breakScript = FindObjectOfType<Break>();
    }

    // Update is called once per frame
    void Update()
    {
        if (breakScript.broken) {
            LevelSpawner.instance.nextScene();
        }
    }
}
