using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ConnectLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] connects = GameObject.FindGameObjectsWithTag("Connect");
        if (connects.All(x => {
            if (x.GetComponent<Connect>()) {
                return x.GetComponent<Connect>().connected;
            } else {
                return true;
            }
        })) {
            LevelSpawner.instance.nextScene();
        }
    }
}
