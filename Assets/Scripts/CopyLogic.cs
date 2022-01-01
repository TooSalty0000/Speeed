using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyLogic : MonoBehaviour
{
    [SerializeField]
    private Transform main;
    [SerializeField]
    private Transform copy;
    // Start is called before the first frame update
    void Start()
    {
        // for each child of main, set a random state of copy
        for (int i = 0; i < main.childCount; i++) {
            int state = Random.Range(0, 2);
            if (state == 0) {
                main.GetChild(i).GetComponent<Copy>().state = false;
            } else {
                main.GetChild(i).GetComponent<Copy>().state = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // compare main children to copy children for copy state
        for (int i = 0; i < main.childCount; i++) {
            if (main.GetChild(i).GetComponent<Copy>().state != copy.GetChild(i).GetComponent<Copy>().state) {
                return;
            }
        }
        LevelSpawner.instance.nextScene();
    }
}
