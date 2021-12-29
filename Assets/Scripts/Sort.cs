using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sort : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {   
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            if (touch.phase == TouchPhase.Began) {
                if (GetComponent<Collider2D>().OverlapPoint(touchPos)) {
                    float newX = transform.position.x + 1;
                    newX = newX > 1.52f ? -1.48f : newX;
                    RaycastHit2D hit = Physics2D.BoxCast(new Vector2(newX, transform.position.y), new Vector2(0.1f, 0.1f), 0, Vector2.zero, 0);
                    hit.collider.gameObject.transform.position = transform.position;
                    transform.position = new Vector3(newX, transform.position.y);
                }
            }

        }
    }

}
