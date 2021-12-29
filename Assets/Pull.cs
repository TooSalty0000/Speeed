using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pull : MonoBehaviour
{
    private bool moving = false;
    private Collider2D col;
    [SerializeField]
    private Vector2 ylimits;
    [SerializeField]
    private Color defaultColor = Color.red;
    public bool pulled = false;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    private int touchID = -1;

    // Update is called once per frame
    void Update()
    {
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
                                transform.position = Vector3.Lerp(new Vector2(transform.position.x, Mathf.Clamp(touchPos.y, ylimits.x, ylimits.y)), transform.position, 0.1f);
                            }
                            if (Mathf.Abs(transform.position.y - ylimits.x) < 0.1f)
                            {
                                pulled = true;
                                GetComponent<SpriteRenderer>().color = Color.green;
                            }
                        }
                        else if (touch.phase == TouchPhase.Ended)
                        {
                            moving = false;
                            transform.position = new Vector3(transform.position.x, ylimits.y);
                            GetComponent<SpriteRenderer>().color = defaultColor;
                            pulled = false;
                            touchID = -1;
                        }
                        break;
                    }
                }
            }
            
        }
    }
}
