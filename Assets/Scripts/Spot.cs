using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot : MonoBehaviour
{
    private void Start() {
        // set x position between -1.674 and 1.674
        transform.position = new Vector3(Random.Range(-1.674f, 1.674f), transform.position.y, transform.position.z);
    }
}
