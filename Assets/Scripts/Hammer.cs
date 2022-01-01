using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    [SerializeField]
    private GameObject nail;
    private bool hammerDown = true;
    private bool nailed = false;
    [SerializeField]
    private float hammerStrength = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) {
            if (Input.GetTouch(0).phase == TouchPhase.Began) {
                hammerDown = true;
            }
        } else {
            hammerDown = false;
            nailed = false;
        }

        if (hammerDown) {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            if (!nailed) {
                lowerNail();
                nailed = true;
            }
        } else {
            transform.rotation = Quaternion.Euler(0, 0, -45);
        }
    }

    private void lowerNail() {
        transform.position = new Vector3(transform.position.x, transform.position.y - hammerStrength, transform.position.z);
        nail.transform.position = new Vector3(nail.transform.position.x, nail.transform.position.y - hammerStrength, nail.transform.position.z);
    }
}
