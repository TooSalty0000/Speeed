using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public Fill fill;
    public bool touching;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fill.particles.Contains(gameObject))
        {
            if (Mathf.Abs(transform.position.x) > 1.7f ) {
                fill.particles.Remove(gameObject);
            }
        }
        if (transform.position.y < -20)
        {
            fill.particles.Remove(gameObject);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name == "Cup")
        {
            touching = true;
        } else if (other.gameObject.tag == "Particle") {
            if (other.gameObject.GetComponent<Particle>().touching) {
                touching = true;
            }
        }
    }
    private void OnCollisionStay2D(Collision2D other) {
        if (other.gameObject.name == "Cup")
        {
            touching = true;
        } else if (other.gameObject.tag == "Particle") {
            if (other.gameObject.GetComponent<Particle>().touching) {
                touching = true;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.name == "Cup")
        {
            touching = false;
        } else if (other.gameObject.tag == "Particle") {
            if (other.gameObject.GetComponent<Particle>().touching) {
                touching = false;
            }
        }
    }
}
