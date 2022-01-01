using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private bool moving = false;
    private Collider2D col;
    public bool moved = false;
    [SerializeField]
    private Collider2D goal;
    private int touchID;

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
        if (Input.touchCount > 0)
        { 
            if (!moving) {
                foreach (var _touch in Input.touches) {
                    if (_touch.phase == TouchPhase.Began) {
                        Vector2 touchPos = Camera.main.ScreenToWorldPoint(_touch.position);
                        if (col.OverlapPoint(touchPos)) {
                            moving = true;
                            touchID = _touch.fingerId;
                            break;
                        }
                    }
                }
            } else {
                foreach (var _touch in Input.touches) {
                    if (_touch .fingerId == touchID) {
                        Touch touch = _touch;
                        Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                        if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                        {
                            if (moving)
                            {
                                transform.position = touchPos;
                            }
                        }
                        else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                        {
                            moving = false;
                            touchID = -1;
                            if (goal.OverlapPoint(transform.position))
                            {
                                moved = true;
                                GetComponent<SpriteRenderer>().color = Color.yellow;
                                enabled = false;
                            }
                        }
                        break;
                    }
                }
            }
        }
    }
}
