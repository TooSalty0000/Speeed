using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved) {
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                transform.position = new Vector3(touchPos.x, transform.position.y);
            }
        }
    }
}
