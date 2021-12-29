using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool moving;
    public bool isStacked = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            //get all touches
            Touch[] touches = Input.touches;
            //loop through all touches
            foreach (Touch touch in touches)
            {
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                
                if (touch.phase == TouchPhase.Began)
                {
                    if (GetComponent<Collider2D>().OverlapPoint(touchPos))
                    {
                        moving = true;
                        rb.isKinematic = true;
                    }
                }
                if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    if (moving)
                    {
                        rb.position = touchPos;
                    }
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    moving = false;
                    rb.isKinematic = false;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // if other is a stack, set isStacked to true
        if (other.gameObject.tag == "Stack")
        {
            isStacked = true;
        }
    }
    void OnCollisionStay2D(Collision2D other)
    {
        // if other is a stack, set isStacked to true
        if (other.gameObject.tag == "Stack")
        {
            isStacked = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        // if other is a stack, set isStacked to true
        if (other.gameObject.tag == "Stack")
        {
            isStacked = false;
        }
    }
}
