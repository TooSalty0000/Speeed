using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickLogic : MonoBehaviour
{
    [SerializeField]
    private GameObject click;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (click.GetComponent<Click>().clickCount <= 0) {
            LevelSpawner.instance.nextScene();
        }
    }
}
