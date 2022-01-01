using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushLogic : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Ball") {
            other.gameObject.GetComponent<Push>().enabled = false;
            LevelSpawner.instance.nextScene();
        } else if (other.gameObject.tag == "Particle") {
            Destroy(other.gameObject);
        }
    }
}
