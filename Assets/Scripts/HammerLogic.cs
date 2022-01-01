using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerLogic : MonoBehaviour
{
    [SerializeField]
    private Transform nail;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (nail.position.y <= -5) {
            LevelSpawner.instance.nextScene();
        }
    }
}
