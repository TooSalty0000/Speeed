using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private bool moving = false;
    private Collider2D col;
    public bool moved = false;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }


    // Update is called once per frame
    void Update()
    {
        // if user touches the object, allow the user to drag it around
        // use ios touch input
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began) {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
                if (hit.collider && hit.collider.gameObject == gameObject) {
                    moving = true;
                }
            } else if (touch.phase == TouchPhase.Moved) {
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                if (moving) {
                    transform.position = touchPos;
                }
            } else if (touch.phase == TouchPhase.Ended) {
                moving = false;
                if (transform.position.x > 1.51f && transform.position.y < 1.85f) {
                    moved = true;
                    GetComponent<SpriteRenderer>().color = Color.yellow;
                } else {
                    moved = false;
                    GetComponent<SpriteRenderer>().color = Color.white;
                }
            }
        }
    }
}
