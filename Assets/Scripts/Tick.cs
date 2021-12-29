using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tick : MonoBehaviour
{
    [SerializeField]
    private float speed = 10;
    private void Update() {
        // ping pong x position between -2.049 and 2.049
        transform.position = new Vector3(Mathf.PingPong(Time.time * speed, 2.049f * 2) - 2.049f, transform.position.y, transform.position.z);
    }
}
